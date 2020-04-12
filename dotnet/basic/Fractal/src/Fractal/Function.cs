using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Fractal
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            var iterations = Convert.ToInt32(request.QueryStringParameters["iterations"]);
            var bottomLeftX = Convert.ToDouble(request.QueryStringParameters["bottomleftx"]);
            var bottomLeftY = Convert.ToDouble(request.QueryStringParameters["bottomlefty"]);
            var topRightX = Convert.ToDouble(request.QueryStringParameters["toprightx"]);
            var topRightY = Convert.ToDouble(request.QueryStringParameters["toprighty"]);
            var stepX = Convert.ToInt32(request.QueryStringParameters["stepx"]);
            var stepY = Convert.ToInt32(request.QueryStringParameters["stepy"]);
            
            var result = Mandelbrot.CalculateArea(
                iterations,
                bottomLeftX,
                bottomLeftY,
                topRightX,
                topRightY,
                stepX,
                stepY);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = $"{{\"result\": {result.ToJsonMatrix()} }}",
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };

            return response;
        }

    }
}
