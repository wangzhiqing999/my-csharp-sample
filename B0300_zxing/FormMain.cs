using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using ZXing;
using ZXing.Client.Result;
using ZXing.Common;
using ZXing.Rendering;



namespace B0300_zxing
{
    public partial class FormMain : Form
    {
        private EncodingOptions EncodingOptions { get; set; }
        private Type Renderer { get; set; }




        private readonly BarcodeReader barcodeReader;
        private readonly IList<ResultPoint> resultPoints;


        public FormMain()
        {
            InitializeComponent();

            Renderer = typeof(BitmapRenderer);



            barcodeReader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions { TryHarder = true }
            };

            barcodeReader.ResultPointFound += point =>
            {
                if (point == null)
                    resultPoints.Clear();
                else
                    resultPoints.Add(point);
            };
            barcodeReader.ResultFound += result =>
            {
                //txtType.Text = result.BarcodeFormat.ToString();
                txtContent.Text += result.Text + Environment.NewLine;
                var parsedResult = ResultParser.parseResult(result);
                if (parsedResult != null)
                {
                    txtContent.Text += "\r\n\r\nParsed result:\r\n" + parsedResult.DisplayResult + Environment.NewLine + Environment.NewLine;
                }
            };
            resultPoints = new List<ResultPoint>();

        }


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (BarcodeFormat format in MultiFormatWriter.SupportedWriters)
            {
                cmbEncoderType.Items.Add(format);
                if (format == BarcodeFormat.QR_CODE)
                {
                    cmbEncoderType.SelectedIndex = cmbEncoderType.Items.Count - 1;
                }
            }
        }



        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncode_Click(object sender, EventArgs e)
        {
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = (BarcodeFormat)cmbEncoderType.SelectedItem,
                    Options = EncodingOptions ?? new EncodingOptions
                    {
                        Height = picEncodedBarCode.Height,
                        Width = picEncodedBarCode.Width
                    },
                    Renderer = (IBarcodeRenderer<Bitmap>)Activator.CreateInstance(Renderer)
                };
                picEncodedBarCode.Image = writer.Write(txtEncoderContent.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// 识别二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncodeDecode_Click(object sender, EventArgs e)
        {
            if (picEncodedBarCode.Image != null)
            {
                var pureBarcodeSetting = barcodeReader.Options.PureBarcode;
                try
                {
                    barcodeReader.Options.PureBarcode = true;
                    Decode((Bitmap)picEncodedBarCode.Image, false, null);
                }
                finally
                {
                    barcodeReader.Options.PureBarcode = pureBarcodeSetting;
                }
            }
        }





        private void Decode(Bitmap image, bool tryMultipleBarcodes, IList<BarcodeFormat> possibleFormats)
        {
            resultPoints.Clear();
            txtContent.Text = String.Empty;

            var timerStart = DateTime.Now.Ticks;
            Result[] results = null;
            barcodeReader.Options.PossibleFormats = possibleFormats;
            if (tryMultipleBarcodes)
                results = barcodeReader.DecodeMultiple(image);
            else
            {
                var result = barcodeReader.Decode(image);
                if (result != null)
                {
                    results = new[] { result };
                }
            }
            var timerStop = DateTime.Now.Ticks;

            if (results == null)
            {
                txtContent.Text = "No barcode recognized";
            }
            // labDuration.Text = new TimeSpan(timerStop - timerStart).Milliseconds.ToString("0 ms");

            if (results != null)
            {
                foreach (var result in results)
                {
                    if (result.ResultPoints.Length > 0)
                    {
                        var rect = new Rectangle((int)result.ResultPoints[0].X, (int)result.ResultPoints[0].Y, 1, 1);
                        foreach (var point in result.ResultPoints)
                        {
                            if (point.X < rect.Left)
                                rect = new Rectangle((int)point.X, rect.Y, rect.Width + rect.X - (int)point.X, rect.Height);
                            if (point.X > rect.Right)
                                rect = new Rectangle(rect.X, rect.Y, rect.Width + (int)point.X - rect.X, rect.Height);
                            if (point.Y < rect.Top)
                                rect = new Rectangle(rect.X, (int)point.Y, rect.Width, rect.Height + rect.Y - (int)point.Y);
                            if (point.Y > rect.Bottom)
                                rect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + (int)point.Y - rect.Y);
                        }
                        using (var g = picEncodedBarCode.CreateGraphics())
                        {
                            g.DrawRectangle(Pens.Green, rect);
                        }
                    }
                }
            }
        }




    }
}
