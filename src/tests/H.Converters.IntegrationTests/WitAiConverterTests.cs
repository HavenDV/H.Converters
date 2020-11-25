using System.Threading.Tasks;
using H.Core;
using H.Recorders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H.Converters.IntegrationTests
{
    [TestClass]
    [Ignore]
    public class WitAiConverterTests
    {
        public static IRecorder CreateRecorder() => new NAudioRecorder();
        public static IConverter CreateConverter() => new WitAiConverter
        {
            Token = "XZS4M3BUYV5LBMEWJKAGJ6HCPWZ5IDGY"
        };

        [TestMethod]
        public async Task StartStreamingRecognitionTest()
        {
            using var converter = CreateConverter();

            await BaseConvertersTests.StartStreamingRecognitionTest(converter, "��������_��������_8000.wav", "��������");
        }

        [TestMethod]
        public async Task StartStreamingRecognitionTest_RealTime()
        {
            using var recorder = CreateRecorder();
            using var converter = CreateConverter();

            await BaseConvertersTests.StartStreamingRecognitionTest_RealTime(recorder, converter, true);
        }

        [TestMethod]
        public async Task ConvertTest()
        {
            using var converter = CreateConverter();

            await BaseConvertersTests.ConvertTest(converter, "��������_��������_8000.wav", "��������");
        }

        [TestMethod]
        public async Task ConvertTest_RealTime()
        {
            using var recorder = CreateRecorder();
            using var converter = CreateConverter();

            await BaseConvertersTests.ConvertTest_RealTime(recorder, converter);
        }
    }
}