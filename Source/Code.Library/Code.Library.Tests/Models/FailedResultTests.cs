﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedResultTests.cs" company="*">
//   *
// </copyright>
// <summary>
//   Defines the FailedResultTests type.
//  Ref : https://github.com/vkhorikov/CSharpFunctionalExtensions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Code.Library.Tests.Models
{
    using Code.Library.Models;

    using Shouldly;

    using Xunit;

    /// <summary>
    /// The failed result tests.
    /// </summary>
    public class FailedResultTests
    {
        #region Public Methods

        [Fact]
        public void Can_create_a_generic_version()
        {
            Result<MyClass> result = Result.Fail<MyClass>("Error message");

            result.Error.ShouldBe("Error message");
            result.IsFailure.ShouldBe(true);
            result.IsSuccess.ShouldBe(false);
        }

        [Fact]
        public void Can_create_a_non_generic_version()
        {
            Result result = Result.Fail("Error message");

            result.Error.ShouldBe("Error message");
            result.IsFailure.ShouldBe(true);
            result.IsSuccess.ShouldBe(false);
        }

        //[Fact]
        //public void Cannot_access_Value_property()
        //{
        //    Result<MyClass> result = Result.Fail<MyClass>("Error message");

        //    Action action = () => { MyClass myClass = result.Value; };

        //    action.ShouldThrow<InvalidOperationException>();
        //}

        [Fact]
        public void Cannot_create_without_error_message()
        {
            Action action1 = () => { Result.Fail(null); };
            Action action2 = () => { Result.Fail(string.Empty); };
            Action action3 = () => { Result.Fail<MyClass>(null); };
            Action action4 = () => { Result.Fail<MyClass>(string.Empty); };

            action1.ShouldThrow<ArgumentNullException>();
            action2.ShouldThrow<ArgumentNullException>();
            action3.ShouldThrow<ArgumentNullException>();
            action4.ShouldThrow<ArgumentNullException>();
        }

        #endregion Public Methods

        #region Private Classes

        private class MyClass
        {
        }

        #endregion Private Classes
    }
}