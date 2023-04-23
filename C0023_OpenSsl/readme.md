生成私钥 （默认格式为 pkcs1 ）
openssl genrsa -out rsa_private_key.pem 1024




Java开发者需将私钥转换成PKCS8格式再做签名使用
私钥转换为pkcs8格式
openssl pkcs8 -topk8 -inform PEM -in rsa_private_key.pem -outform PEM -nocrypt
控制台打印出来的为转换为pkcs8格式的私钥

-----BEGIN PRIVATE KEY-----
MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBALOhtU1lEYk6ILGQ
bqjybqFq8DRvDHZRJfZGbO2dhT+iKFCdV34ZmJXK6VGDDkbtqnknSNdsqBO7CUvY
m9ddHqVaig3ZB2nm+s1FQT/+uqvFoeu10wgLEqgcoAmJhss/Urmsk/EswrMGjukD
R1dPrciVRS/ZKzUuMKok6PECem9FAgMBAAECgYEArCpYF5a/6POSdD1HIpxBVmql
UMwCeMAsD0/OhSuNk8C6vREg01Z6/U6esyZWH7sYwcfaM8cLjOWd8ljofNDeVeXO
gr7UsJ1fk5BO4ZbZwTZsJrX6h5Oqt4AOaSeRYMPfXSVCe+/ObVwBsXjboMeUSPuz
dxP0d3RmhiioWs5KwOECQQDvfePO6OY7T5bPm0ejeee1t9w/uHnaUlLGaYzgHG1E
PMH8h65G0QsLXgKrtC4VncO2nu7bab3LTNb+hYkTFzN9AkEAwAOEhCcduC4ZvUZl
4ot7v43uYAuwgpqvuu3eA/XwOm2XtpICVvZws8Up56vFW5NtC8GYBQhSqFmtJPOc
Vh5laQJBAJqd9SCVXma2WJBKGPMi9gRs4oZFDG52LbipVmkuESE39Kmb01knBvFc
zW6bUhFknIFflKgVWZJSVo9WGQw5M2UCQELD9lwNTeQxA3ow9FRls83TiEOVTPbc
2qXg+AXginuGh+5PrsiWQHIB6KRJsgI5rP0df8KgNj2bkPz8SCwZvaECQANLWBNr
4pAatB6/9+uX061oKyl5yDJK3k1fotT9FDju7L0mxKJonQxfP3p2tNu2+Gs0j2J/
VxXF2NWeksHwPZU=
-----END PRIVATE KEY-----




生成公钥
openssl rsa -in rsa_private_key.pem -pubout -out rsa_public_key.pem


[root@localhost ~]# more rsa_public_key.pem
-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCzobVNZRGJOiCxkG6o8m6havA0
bwx2USX2RmztnYU/oihQnVd+GZiVyulRgw5G7ap5J0jXbKgTuwlL2JvXXR6lWooN
2Qdp5vrNRUE//rqrxaHrtdMICxKoHKAJiYbLP1K5rJPxLMKzBo7pA0dXT63IlUUv
2Ss1LjCqJOjxAnpvRQIDAQAB
-----END PUBLIC KEY-----




Java 目录下的是 Java 使用私钥签名 / 使用公钥验证签名 的 SHA1withRSA 操作.


TestSHA1withRSA 是 C# 下的操作， 与  Java 的结果对比后，签名结果一致。


注意：
算法区分 SHA1 / SHA256

也就是 C# 用 SHA1 处理的结果，  是和 Java 用 SHA1 处理的结果一致的。
也就是 C# 用 SHA256 处理的结果，  是和 Java 用 SHA256 处理的结果一致的。

但是  C# 用 SHA1 处理的结果，  是和 Java 用 SHA256 处理的结果是不一致的。
