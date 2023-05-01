using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Helpers
{
    public static class ResponseBuilder
    {
        public static ResponseModel Response(int statusCode) => new(statusCode);
        public static ResponseModel OkResponse() => new(200);
        public static ResponseModel NoContentResponse() => new(204);
        public static ResponseModel BadRequestResponse() => new(400);
        public static ResponseModel UnauthorizedResponse() => new(401);
        public static ResponseModel ForbiddenResponse() => new(403);
        public static ResponseModel NotFoundResponse() => new(404);
        public static ResponseModel ConflictResponse() => new(409);
        public static ResponseModel PreconditionResponse() => new(412);
        public static ResponseModel UnprocessableEntityResponse() => new(422);
        public static ResponseModel TooManyRequestsResponse() => new(429);
        public static ResponseModel ErrorResponse() => new(500);
        public static ResponseModel BadGatewayResponse() => new(502);

        public static ResponseModel<T> Response<T>(int statusCode, T content) => new(statusCode, content);
        public static ResponseModel<T?> Response<T>(int statusCode) => new(statusCode, default);
        public static ResponseModel<T> OkResponse<T>(T content) => new(200, content);
        public static ResponseModel<T> CreatedResponse<T>(T content) => new(201, content);
        public static ResponseModel<T> BadRequestResponse<T>(T content) => new(400, content);
        public static ResponseModel<T> UnauthorizedResponse<T>(T content) => new(401, content);
        public static ResponseModel<T> ForbiddenResponse<T>(T content) => new(403, content);
        public static ResponseModel<T> NotFoundResponse<T>(T content) => new(404, content);
        public static ResponseModel<T> ConflictResponse<T>(T content) => new(409, content);
        public static ResponseModel<T> UnprocessableEntityResponse<T>(T content) => new(422, content);
        public static ResponseModel<T> TooManyRequestsResponse<T>(T content) => new(429, content);
        public static ResponseModel<T> ErrorResponse<T>(T content) => new(500, content);
        public static ResponseModel<Dictionary<string, string>> ErrorResponse(string message) => new(500, new Dictionary<string, string>() { { "Error", message } });
        public static ResponseModel<T> BadGatewayResponse<T>(T content) => new(502, content);
    }
}
