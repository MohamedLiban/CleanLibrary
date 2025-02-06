using System;
using FluentAssertions;
using Xunit;
using CleanLibrary.Application.Common;

namespace CleanLibrary.Test.Common
{
    public class OperationResultTests
    {
        [Fact]
        public void Failure_ShouldThrowException_WhenErrorMessageIsNullOrEmpty()
        {
            Action act = () => OperationResult<string>.Failure("");

            act.Should().Throw<ArgumentException>()
                .WithMessage("*Error message cannot be null or empty*");
        }
    }
}
