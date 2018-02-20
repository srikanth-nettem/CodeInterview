using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.State;
using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Validations
{
    [Trait("Category", "unit")]
    public class DressValidatorTests
    {
        private readonly IDressValidator _dressValidator;
        private readonly IRulesEngine _rulesEngine;
        private readonly IStateManager _stateManager;


        public static IEnumerable<object[]> RulesData1 = new List<object[]>(){
                                                                new object[] {
                                                                                new Dictionary<Dress, bool>()
                                                                                {
                                                                                    {Dress.Pajamas_Off,true },
                                                                                    {Dress.ShirtOn, true }
                                                                                },
                                                                                new {State=Dress.Pajamas_Off, flag=true},
                                                                                new {State=Dress.ShirtOn, flag=true}
                                                                              },
                                                                new object[] {
                                                                                new Dictionary<Dress, bool>()
                                                                                {
                                                                                    {Dress.Pajamas_Off,true },
                                                                                    {Dress.ShirtOn, false }
                                                                                },
                                                                                new {State=Dress.Pajamas_Off, flag=true},
                                                                                new {State=Dress.ShirtOn, flag=false}

                                                                              }
                                                                            };

        public static IEnumerable<object[]> RulesData2 = new List<object[]>(){
                                                                new object[] {
                                                                                new Dictionary<Dress, bool>()
                                                                                {
                                                                                    {Dress.Pajamas_Off,true },
                                                                                    {Dress.ShirtOn, true }
                                                                                },
                                                                                new {State=Dress.Pajamas_Off, flag=true},
                                                                                new {State=Dress.ShirtOn, flag=false},
                                                                              },
                                                                new object[] {
                                                                                new Dictionary<Dress, bool>()
                                                                                {
                                                                                    {Dress.Pajamas_Off,false },
                                                                                    {Dress.ShirtOn, true }
                                                                                },
                                                                                new {State=Dress.Pajamas_Off, flag=false},
                                                                                new {State=Dress.ShirtOn, flag=false}
                                                                              }
                                                                            };

        public DressValidatorTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _rulesEngine = Substitute.For<IRulesEngine>();
            _dressValidator = new DressValidator(_rulesEngine, _stateManager);
        }

        [Theory]
        [MemberData(nameof(RulesData1))]
        public void ShouldReturnTrueIfRulesAreMet(IDictionary<Dress, bool> rules, dynamic state1, dynamic state2)
        {
            //given
            _rulesEngine.GetRule(Dress.JacketOn).Returns(rules);
            
            _stateManager.isStateVisited((Dress)state1.State).Returns((bool)state1.flag);
            _stateManager.isStateVisited((Dress)state2.State).Returns((bool)state2.flag);

            Assert.True(_dressValidator.isValid(Dress.JacketOn));
        }

        [Theory]
        [MemberData(nameof(RulesData2))]
        public void ShouldReturnFalseIfRulesAreNotMet(IDictionary<Dress, bool> rules, dynamic state1, dynamic state2)
        {
            //given
            _rulesEngine.GetRule(Dress.JacketOn).Returns(new Dictionary<Dress, bool>()
            {
                {Dress.Pajamas_Off,true },
                {Dress.ShirtOn, true }
            });
            _stateManager.isStateVisited((Dress)state1.State).Returns((bool)state2.flag);
            _stateManager.isStateVisited((Dress)state2.State).Returns((bool)state2.flag);

            Assert.False(_dressValidator.isValid(Dress.JacketOn));
        }

    }
}
