using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Fractal;

namespace Fractal.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TetGetMethod()
        {
            // Arrange
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            Functions functions = new Functions();


            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();

            request.QueryStringParameters = new Dictionary<string, string>();
            request.QueryStringParameters.Add("iterations", "10");
            request.QueryStringParameters.Add("bottomleftx", "0.0");
            request.QueryStringParameters.Add("bottomlefty", "0.0");
            request.QueryStringParameters.Add("toprightx", "1.0");
            request.QueryStringParameters.Add("toprighty", "1.0");
            request.QueryStringParameters.Add("stepx", "10");
            request.QueryStringParameters.Add("stepy", "10");

            // Act
            response = functions.Get(request, context);
            Assert.Equal(200, response.StatusCode);
            Assert.Equal("application/json", response.Headers["Content-Type"]);
            Assert.True(response.Body.IndexOf("result") > 0);
        }

        [Fact]
        public void CanTurnListOfIntsIntoJsonArray()
        {
            // Arrange
            var intList = new List<int>{1, 2, 3};

            // Act
            var json = intList.ToJsonArray();

            // Assert
            Assert.Equal("[1,2,3]", json);
        }

        [Fact]
        public void CanTurnMatrixOfIntsIntoJsonMatrix()
        {
            // Arrange
            var intMatrix = new List<List<int>>{
                new List<int>{1, 2, 3},
                new List<int>{4, 5, 6},
                new List<int>{7, 8, 9} 
                };
            
            // Act
            var actual = intMatrix.ToJsonMatrix();

            // Assert
            Assert.Equal("[[1,2,3],[4,5,6],[7,8,9]]", actual);
        }
    }
}
