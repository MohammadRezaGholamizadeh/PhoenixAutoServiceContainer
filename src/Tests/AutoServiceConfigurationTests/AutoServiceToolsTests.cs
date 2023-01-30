using AutoServiceContainer;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutoServiceConfigurationTests
{
    public class AutoServiceToolsTests
    {
        [Fact]
        public void
            Add_element_to_dictionaryList_WithAddMockedMethodOn_Dictionary()
        {
            var dictionaryList = new Dictionary<Type, object>();

            dictionaryList.AddMockedParameter(typeof(string), "Test");

            dictionaryList.Should().HaveCount(1);
            dictionaryList.Single().Key.Should().Be(typeof(string));
            dictionaryList.Single().Value.Should().Be("Test");
        }

        [Fact]
        public void
            Create_dictionaryList_WithMockObjectListCreatorMethod()
        {
            var dictionary = AutoServiceTools.MockObjectListCreator();

            dictionary.GetType().Should().Be(typeof(Dictionary<Type, object>));
            dictionary.Should().NotBeNull();
            dictionary.Should().HaveCount(0);
        }
    }


}
