﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetEnrollmentsResultParser
        : JsonResultParserBase<IGetEnrollments>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _uuidSerializer;

        public GetEnrollmentsResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _uuidSerializer = serializerResolver.Get("Uuid");
        }

        protected override IGetEnrollments ParserData(JsonElement data)
        {
            return new GetEnrollments
            (
                ParseGetEnrollmentsEnrollments(data, "enrollments")
            );

        }

        private global::System.Collections.Generic.IReadOnlyList<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollment> ParseGetEnrollmentsEnrollments(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            int objLength = obj.GetArrayLength();
            var list = new global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollment[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Enrollment
                (
                    DeserializeString(element, "name"),
                    DeserializeString(element, "emailAddress"),
                    DeserializeString(element, "mobileNumber"),
                    DeserializeUuid(element, "id")
                );

            }

            return list;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private System.Guid DeserializeUuid(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.Guid)_uuidSerializer.Deserialize(value.GetString());
        }
    }
}
