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
                Variables = new List<Variable>
                {
                    new Variable {Key = "astring", Name = "A string", Description = "description", Required = true, Type = VariableType.Text},
                    new Variable {Key = "anumber", Name = "A number", Description = "description", Required = false, Type = VariableType.Number},
                    new Variable {Key = "aboolean", Name = "A boolean", Description = "description", Required = true, Type = VariableType.Checkbox},
                },
            };

            var newApp = AppManifest.Parse(AppManifest.Produce(app));

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(3));
            Assert.That(VariablePresent(newApp.Variables, VariableType.Text, true));
            Assert.That(VariablePresent(newApp.Variables, VariableType.Number, false));
            Assert.That(VariablePresent(newApp.Variables, VariableType.Checkbox, true));
        }

        private bool VariablePresent(List<Variable> variables, VariableType variableType, bool required)
        {
            return variables.Any(v => v.Type == variableType && v.Required == required);
        }
    }
}