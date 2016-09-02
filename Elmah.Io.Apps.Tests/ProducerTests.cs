using System;
using System.Collections.Generic;
using System.Linq;
using Elmah.Io.Apps.Manifest;
using NUnit.Framework;

namespace Elmah.Io.Apps.Tests
{
    public class ProducerTests
    {
        [Test]
        public void CanProduceHttp()
        {
            var app = new App
            {
                Rule = new Rule
                {
                    Title = "title",
                    Query = "*",
                    Then = new ThenHttp(new Uri("http://localhost"))
                    {
                        Method = "POST",
                        ContentType = "application/json",
                        Body = "{}"
                    }
                }
            };

            var newApp = AppManifest.Parse(AppManifest.Produce(app));

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Rule, Is.Not.Null);
            Assert.That(newApp.Rule.Then, Is.Not.Null);
            Assert.That(newApp.Rule.Then.Type, Is.EqualTo(ThenType.Http));
            var http = newApp.Rule.Then as ThenHttp;
            Assert.That(http != null);
            Assert.That(http.Url, Is.EqualTo(new Uri("http://localhost")));
            Assert.That(http.Method, Is.EqualTo("POST"));
            Assert.That(http.ContentType, Is.EqualTo("application/json"));
            Assert.That(http.Body, Is.EqualTo("{}"));
        }

        [Test]
        public void CanProduceEmail()
        {
            var app = new App
            {
                Rule = new Rule
                {
                    Title = "title",
                    Query = "*",
                    Then = new ThenEmail("thomasardal@gmail.com")
                }
            };

            var newApp = AppManifest.Parse(AppManifest.Produce(app));

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Rule, Is.Not.Null);
            Assert.That(newApp.Rule.Then, Is.Not.Null);
            Assert.That(newApp.Rule.Then.Type, Is.EqualTo(ThenType.Email));
            var http = newApp.Rule.Then as ThenEmail;
            Assert.That(http != null);
            Assert.That(http.Email, Is.EqualTo("thomasardal@gmail.com"));
        }

        [Test]
        public void CanProduceIgnore()
        {
            var app = new App
            {
                Rule = new Rule
                {
                    Title = "title",
                    Query = "*",
                    Then = new ThenIgnore()
                }
            };

            var newApp = AppManifest.Parse(AppManifest.Produce(app));

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Rule, Is.Not.Null);
            Assert.That(newApp.Rule.Then, Is.Not.Null);
            Assert.That(newApp.Rule.Then.Type, Is.EqualTo(ThenType.Ignore));
            var http = newApp.Rule.Then as ThenIgnore;
            Assert.That(http != null);
        }

        [Test]
        public void CanProduceHide()
        {
            var app = new App
            {
                Rule = new Rule
                {
                    Title = "title",
                    Query = "*",
                    Then = new ThenHide()
                }
            };

            var newApp = AppManifest.Parse(AppManifest.Produce(app));

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Rule, Is.Not.Null);
            Assert.That(newApp.Rule.Then, Is.Not.Null);
            Assert.That(newApp.Rule.Then.Type, Is.EqualTo(ThenType.Hide));
            var http = newApp.Rule.Then as ThenHide;
            Assert.That(http != null);
        }

        [Test]
        public void CanProduceVariables()
        {
            var app = new App
            {
                Variables = new List<IVariable>
                {
                    new TextVariable {Key = "astring", Name = "A string", Example = "Some string", Description = "description", Required = true},
                    new TextVariable {Key = "anotherstring", Name = "Another string", Example = "Some string", Description = "description", Required = false},
                    new TextVariable {Key = "asimplestring"},
                    new ChoiceVariable {Key = "aselect", Name = "A select", Values = new [] {"One", "Two", "Three"}},
                    new NumberVariable {Key = "anumber", Name = "A number"},
                    new BoolVariable {Key = "acheckbox", Name = "A checkbox", Default = true},
                },
            };

            var produce = AppManifest.Produce(app);
            var newApp = AppManifest.Parse(produce);

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(6));
            Assert.That(VariablePresent(newApp.Variables, "astring", VariableType.Text, true));
            Assert.That(VariablePresent(newApp.Variables, "anotherstring", VariableType.Text, false));
            Assert.That(VariablePresent(newApp.Variables, "asimplestring", VariableType.Text, false));
            Assert.That(VariablePresent(newApp.Variables, "aselect", VariableType.Choice, false));
            Assert.That(VariablePresent(newApp.Variables, "anumber", VariableType.Number, false));
            Assert.That(VariablePresent(newApp.Variables, "acheckbox", VariableType.Bool, false));
        }

        [Test]
        public void CanProduceMarkerApp()
        {
            var app = new App();
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
        }

        [Test]
        public void CanProduceAppWithChoice()
        {
            var app = new App
            {
                Variables = new List<IVariable>
                {
                    new ChoiceVariable {Key = "myselect", Values = new[] {"One", "Two", "three"}}
                }
            };
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
            Assert.That(newApp.Variables != null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(1));
            Assert.That(newApp.Variables.First() is ChoiceVariable);
            Assert.That((newApp.Variables.First() as ChoiceVariable).Values.Length, Is.EqualTo(3));
        }

        [Test]
        public void CanProduceAppWithNumberVariable()
        {
            var app = new App
            {
                Variables = new List<IVariable>
                {
                    new NumberVariable {Key = "myselect", Default = 42}
                }
            };
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
            Assert.That(newApp.Variables != null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(1));
            Assert.That(newApp.Variables.First() is NumberVariable);
            Assert.That((newApp.Variables.First() as NumberVariable).Default, Is.EqualTo(42));
        }

        [Test]
        public void CanProduceAppWithBoolVariable()
        {
            var app = new App
            {
                Variables = new List<IVariable>
                {
                    new BoolVariable {Key = "mybool", Default = true}
                }
            };
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
            Assert.That(newApp.Variables != null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(1));
            Assert.That(newApp.Variables.First() is BoolVariable);
            Assert.That((newApp.Variables.First() as BoolVariable).Default, Is.EqualTo(true));
        }

        private bool VariablePresent(List<IVariable> variables, string key, VariableType variableType, bool required)
        {
            return variables.Any(v => v.Key == key && v.Type == variableType && v.Required == required);
        }
    }
}