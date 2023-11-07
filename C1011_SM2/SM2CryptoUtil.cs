using System;
using System.Text.RegularExpressions;

using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;



namespace C1011_SM2
{

    /// <summary>
    /// Copy From
    /// https://gitee.com/Karl_Albright/CryptoHelper/blob/master/src/CryptoHelper/SM2CryptoUtil.cs
    /// </summary>
    public class SM2CryptoUtil
    {
        public SM2CryptoUtil(byte[] pubkey, byte[] privkey, Mode mode)
        {
            this.pubkey = pubkey;
            this.privkey = privkey;
            this.mode = mode;
        }
        public SM2CryptoUtil(string pubkey, string privkey, Mode mode = Mode.C1C2C3, bool isPkcs8 = false)
        {
            if (!isPkcs8)
            {
                if (pubkey != null) this.pubkey = Decode(pubkey);
                if (privkey != null) this.privkey = Decode(privkey);
            }
            else
            {
                if (pubkey != null) this.pubkey = ((ECPublicKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(pubkey))).Q.GetEncoded();
                if (privkey != null) this.privkey = ((ECPrivateKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privkey))).D.ToByteArray();
            }
            this.mode = mode;
        }
        byte[] pubkey;
        byte[] privkey;
        Mode mode;
        ICipherParameters _privateKeyParameters;
        ICipherParameters PrivateKeyParameters
        {
            get
            {
                var r = _privateKeyParameters;
                if (r == null) r = _privateKeyParameters = new ECPrivateKeyParameters(new BigInteger(1, privkey), new ECDomainParameters(GMNamedCurves.GetByName("SM2P256V1")));
                return r;
            }
        }
        ICipherParameters _publicKeyParameters;
        ICipherParameters PublicKeyParameters
        {
            get
            {
                var r = _publicKeyParameters;
                if (r == null)
                {
                    var x9ec = GMNamedCurves.GetByName("SM2P256V1");
                    r = _publicKeyParameters = new ECPublicKeyParameters(x9ec.Curve.DecodePoint(pubkey), new ECDomainParameters(x9ec));
                }
                return r;
            }
        }

        public static void GenerateKeyHex(out string pubkey, out string privkey)
        {
            GenerateKey(out var a, out var b);
            pubkey = Hex.ToHexString(a);
            privkey = Hex.ToHexString(b);
        }
        public static void GenerateKey(out byte[] pubkey, out byte[] privkey)
        {
            var g = new ECKeyPairGenerator();
            g.Init(new ECKeyGenerationParameters(new ECDomainParameters(GMNamedCurves.GetByName("SM2P256V1")), new SecureRandom()));
            var k = g.GenerateKeyPair();
            pubkey = ((ECPublicKeyParameters)k.Public).Q.GetEncoded(false);
            privkey = ((ECPrivateKeyParameters)k.Private).D.ToByteArray();
        }

        public byte[] Decrypt(byte[] data)
        {
            if (mode == Mode.C1C3C2) data = C132ToC123(data);
            var sm2 = new SM2Engine(new SM3Digest());
            sm2.Init(false, this.PrivateKeyParameters);
            return sm2.ProcessBlock(data, 0, data.Length);
        }
        public byte[] Encrypt(byte[] data)
        {
            var sm2 = new SM2Engine(new SM3Digest());
            sm2.Init(true, new ParametersWithRandom(PublicKeyParameters));
            data = sm2.ProcessBlock(data, 0, data.Length);
            if (mode == Mode.C1C3C2) data = C123ToC132(data);
            return data;
        }
        public byte[] Sign(byte[] msg, byte[] id = null)
        {
            var sm2 = new SM2Signer(new SM3Digest());
            ICipherParameters cp;
            if (id != null) cp = new ParametersWithID(new ParametersWithRandom(PrivateKeyParameters), id);
            else cp = new ParametersWithRandom(PrivateKeyParameters);
            sm2.Init(true, cp);
            sm2.BlockUpdate(msg, 0, msg.Length);
            return sm2.GenerateSignature();
        }
        public bool VerifySign(byte[] msg, byte[] signature, byte[] id = null)
        {
            var sm2 = new SM2Signer(new SM3Digest());
            ICipherParameters cp;
            if (id != null) cp = new ParametersWithID(PublicKeyParameters, id);
            else cp = PublicKeyParameters;
            sm2.Init(false, cp);
            sm2.BlockUpdate(msg, 0, msg.Length);
            return sm2.VerifySignature(signature);
        }
        static byte[] C123ToC132(byte[] c1c2c3)
        {
            var gn = GMNamedCurves.GetByName("SM2P256V1");
            int c1Len = (gn.Curve.FieldSize + 7) / 8 * 2 + 1; //sm2p256v1的这个固定65。可看GMNamedCurves、ECCurve代码。
            int c3Len = 32; //new SM3Digest().getDigestSize();
            byte[] result = new byte[c1c2c3.Length];
            Array.Copy(c1c2c3, 0, result, 0, c1Len); //c1
            Array.Copy(c1c2c3, c1c2c3.Length - c3Len, result, c1Len, c3Len); //c3
            Array.Copy(c1c2c3, c1Len, result, c1Len + c3Len, c1c2c3.Length - c1Len - c3Len); //c2
            return result;
        }
        static byte[] C132ToC123(byte[] c1c3c2)
        {
            var gn = GMNamedCurves.GetByName("SM2P256V1");
            int c1Len = (gn.Curve.FieldSize + 7) / 8 * 2 + 1;
            int c3Len = 32; //new SM3Digest().getDigestSize();
            byte[] result = new byte[c1c3c2.Length];
            Array.Copy(c1c3c2, 0, result, 0, c1Len); //c1: 0->65
            Array.Copy(c1c3c2, c1Len + c3Len, result, c1Len, c1c3c2.Length - c1Len - c3Len); //c2
            Array.Copy(c1c3c2, c1Len, result, c1c3c2.Length - c3Len, c3Len); //c3
            return result;
        }
        static byte[] Decode(string key)
        {
            return Regex.IsMatch(key, "^[0-9a-f]+$", RegexOptions.IgnoreCase) ? Hex.Decode(key) : Convert.FromBase64String(key);
        }
        public enum Mode
        {
            C1C2C3, C1C3C2
        }
    }
}
