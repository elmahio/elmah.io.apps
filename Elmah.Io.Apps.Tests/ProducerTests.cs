﻿using System;
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
                    new Variable {Type = VariableType.Text, Key = "astring", Name = "A string", Example = "Some string", Description = "description", Required = true},
                    new Variable {Type = VariableType.Text, Key = "anotherstring", Name = "Another string", Example = "Some string", Description = "description", Required = false},
                    new Variable {Type = VariableType.Text, Key = "asimplestring"},
                    new Variable {Type = VariableType.Select, Key = "aselect", Name = "A select", Values = new [] {"One", "Two", "Three"}},
                    new Variable {Type = VariableType.Number, Key = "anumber", Name = "A number"},
                    new Variable {Type = VariableType.Checkbox, Key = "acheckbox", Name = "A checkbox", Default = true},
                },
            };

            var newApp = AppManifest.Parse(AppManifest.Produce(app));

            Assert.That(newApp, Is.Not.Null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(6));
            Assert.That(VariablePresent(newApp.Variables, "astring", VariableType.Text, true));
            Assert.That(VariablePresent(newApp.Variables, "anotherstring", VariableType.Text, false));
            Assert.That(VariablePresent(newApp.Variables, "asimplestring", VariableType.Text, false));
            Assert.That(VariablePresent(newApp.Variables, "aselect", VariableType.Select, false));
            Assert.That(VariablePresent(newApp.Variables, "anumber", VariableType.Number, false));
            Assert.That(VariablePresent(newApp.Variables, "acheckbox", VariableType.Checkbox, false));
        }

        [Test]
        public void CanProduceMarkerApp()
        {
            var app = new App();
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
        }

        [Test]
        public void CanProduceAppWithSelect()
        {
            var app = new App
            {
                Variables = new List<Variable>
                {
                    new Variable {Type = VariableType.Select, Key = "myselect", Values = new[] {"One", "Two", "three"}}
                }
            };
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
            Assert.That(newApp.Variables != null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(1));
            Assert.That(newApp.Variables.First().Values.Length, Is.EqualTo(3));
        }

        [Test]
        public void CanProduceAppWithNumberVariable()
        {
            var app = new App
            {
                Variables = new List<Variable>
                {
                    new Variable {Type = VariableType.Number, Key = "myselect", Default = 42}
                }
            };
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
            Assert.That(newApp.Variables != null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(1));
            Assert.That(newApp.Variables.First().Default, Is.EqualTo(42));
        }

        [Test]
        public void CanProduceAppWithCheckboxVariable()
        {
            var app = new App
            {
                Variables = new List<Variable>
                {
                    new Variable {Key = "mycheckbox", Default = true}
                }
            };
            var newApp = AppManifest.Parse(AppManifest.Produce(app));
            Assert.That(newApp != null);
            Assert.That(newApp.Variables != null);
            Assert.That(newApp.Variables.Count, Is.EqualTo(1));
            Assert.That(newApp.Variables.First().Default, Is.EqualTo(true));
        }

        private bool VariablePresent(List<Variable> variables, string key, VariableType variableType, bool required)
        {
            return variables.Any(v => v.Key == key && v.Type == variableType && v.Required == required);
        }
    }
}