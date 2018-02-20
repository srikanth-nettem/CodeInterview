using CodeInterview.WeatherDress.Core.Utils;
using Xunit;

namespace CodeInterview.WeatherDress.Core.Tests.Utils
{
    public class ConstantsTests
    {
        [Fact(DisplayName="should have SHIRT property as 'shirt'")]
        void ShouldHaveSHIRT()
        {
            Assert.Contains("shirt", Constants.SHIRT);
        }

        [Fact(DisplayName = "should have PANTS property as 'pants'")]
        void ShouldHavePANTS()
        {
            Assert.Contains("pants", Constants.PANTS);
        }

        [Fact(DisplayName = "should have SHORTS property as 'shorts'")]
        void ShouldHaveSHORTS()
        {
            Assert.Contains("shorts", Constants.SHORTS);
        }

        [Fact(DisplayName = "should have TSHIRT property as 't-shirt'")]
        void ShouldHaveTSHIRT()
        {
            Assert.Contains("t-shirt", Constants.TSHIRT);
        }

        [Fact(DisplayName = "should have HAT property as 'hat'")]
        void ShouldHaveHAT()
        {
            Assert.Contains("hat", Constants.HAT);
        }

        [Fact(DisplayName = "should have SUNVISOR property as 'sun visor'")]
        void ShouldHaveSUNVISOR()
        {
            Assert.Contains("sun visor", Constants.SUN_VISOR);
        }

        [Fact(DisplayName = "should have SANDALS property as 'sandals'")]
        void ShouldHaveSANDALS()
        {
            Assert.Contains("sandals", Constants.SANDALS);
        }

        [Fact(DisplayName = "should have BOOTS property as 'boots'")]
        void ShouldHaveBOOTS()
        {
            Assert.Contains("boots", Constants.BOOTS);
        }

        [Fact(DisplayName = "should have JACKET property as 'jacket'")]
        void ShouldHaveJACKET()
        {
            Assert.Contains("jacket", Constants.JACKET);
        }

        [Fact(DisplayName = "should have SOCKS property as 'socks'")]
        void ShouldHaveSOCKS()
        {
            Assert.Contains("socks", Constants.SOCKS);
        }

        [Fact(DisplayName = "should have PAJAMAS_OFF property as 'Removing PJs'")]
        void ShouldHavePAJAMAS_OFF()
        {
            Assert.Contains("Removing PJs", Constants.PAJAMAS_OFF);
        }

        [Fact(DisplayName = "should have LEAVEHOME property as 'leaving house'")]
        void ShouldHaveLEAVEHOME()
        {
            Assert.Contains("leaving house", Constants.LEAVING_HOME);
        }
    }
}
