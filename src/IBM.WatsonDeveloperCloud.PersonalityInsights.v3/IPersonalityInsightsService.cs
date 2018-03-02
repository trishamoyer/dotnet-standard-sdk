/**
* Copyright 2018 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using IBM.WatsonDeveloperCloud.PersonalityInsights.v3.Model;

namespace IBM.WatsonDeveloperCloud.PersonalityInsights.v3
{
    public interface IPersonalityInsightsService
    {
        /// <summary>
        /// Generates a personality profile based on input text. Derives personality insights for up to 20 MB of input content written by an author, though the service requires much less text to produce an accurate profile; for more information, see [Providing sufficient input](https://console.bluemix.net/docs/services/personality-insights/input.html#sufficient). Accepts input in Arabic, English, Japanese, Korean, or Spanish and produces output in one of eleven languages. Provide plain text, HTML, or JSON content, and receive results in JSON or CSV format.
        /// </summary>
        /// <param name="content">A maximum of 20 MB of content to analyze, though the service requires much less text; for more information, see [Providing sufficient input](https://console.bluemix.net/docs/services/personality-insights/input.html#sufficient). A JSON request must conform to the `Content` model.</param>
        /// <param name="contentType">The type of the input: application/json, text/html, or text/plain. A character encoding can be specified by including a `charset` parameter. For example, 'text/html;charset=utf-8'.</param>
        /// <param name="contentLanguage">The language of the input text for the request: Arabic, English, Japanese, Korean, or Spanish. Regional variants are treated as their parent language; for example, `en-US` is interpreted as `en`. The effect of the `contentLanguage` header depends on the `Content-Type` header. When `Content-Type` is `text/plain` or `text/html`, `contentLanguage` is the only way to specify the language. When `Content-Type` is `application/json`, `contentLanguage` overrides a language specified with the `language` parameter of a `ContentItem` object, and content items that specify a different language are ignored; omit this header to base the language on the specification of the content items. You can specify any combination of languages for `contentLanguage` and `Accept-Language`. (optional, default to en)</param>
        /// <param name="acceptLanguage">The desired language of the response. For two-character arguments, regional variants are treated as their parent language; for example, `en-US` is interpreted as `en`. You can specify any combination of languages for the input and response content. (optional, default to en)</param>
        /// <param name="rawScores">If `true`, a raw score in addition to a normalized percentile is returned for each characteristic; raw scores are not compared with a sample population. If `false` (the default), only normalized percentiles are returned. (optional, default to false)</param>
        /// <param name="csvHeaders">If `true`, column labels are returned with a CSV response; if `false` (the default), they are not. Applies only when the `Accept` header is set to `text/csv`. (optional, default to false)</param>
        /// <param name="consumptionPreferences">If `true`, information about consumption preferences is returned with the results; if `false` (the default), the response does not include the information. (optional, default to false)</param>
        /// <returns><see cref="Profile" />Profile</returns>
        Profile Profile(Content content, string contentType, string contentLanguage = null, string acceptLanguage = null, bool? rawScores = null, bool? csvHeaders = null, bool? consumptionPreferences = null);

        /// <summary>
        /// Generates a personality profile based on input text. Derives personality insights for up to 20 MB of input content written by an author, though the service requires much less text to produce an accurate profile; for more information, see [Providing sufficient input](https://console.bluemix.net/docs/services/personality-insights/input.html#sufficient). Accepts input in Arabic, English, Japanese, Korean, or Spanish and produces output in one of eleven languages. Provide plain text, HTML, or JSON content, and receive results in JSON or CSV format.
        /// </summary>
        /// <param name="content">A maximum of 20 MB of content to analyze, though the service requires much less text; for more information, see [Providing sufficient input](https://console.bluemix.net/docs/services/personality-insights/input.html#sufficient). A JSON request must conform to the `Content` model.</param>
        /// <param name="contentType">The type of the input: application/json, text/html, or text/plain. A character encoding can be specified by including a `charset` parameter. For example, 'text/html;charset=utf-8'.</param>
        /// <param name="contentLanguage">The language of the input text for the request: Arabic, English, Japanese, Korean, or Spanish. Regional variants are treated as their parent language; for example, `en-US` is interpreted as `en`. The effect of the `contentLanguage` header depends on the `Content-Type` header. When `Content-Type` is `text/plain` or `text/html`, `contentLanguage` is the only way to specify the language. When `Content-Type` is `application/json`, `contentLanguage` overrides a language specified with the `language` parameter of a `ContentItem` object, and content items that specify a different language are ignored; omit this header to base the language on the specification of the content items. You can specify any combination of languages for `contentLanguage` and `Accept-Language`. (optional, default to en)</param>
        /// <param name="acceptLanguage">The desired language of the response. For two-character arguments, regional variants are treated as their parent language; for example, `en-US` is interpreted as `en`. You can specify any combination of languages for the input and response content. (optional, default to en)</param>
        /// <param name="rawScores">If `true`, a raw score in addition to a normalized percentile is returned for each characteristic; raw scores are not compared with a sample population. If `false` (the default), only normalized percentiles are returned. (optional, default to false)</param>
        /// <param name="csvHeaders">If `true`, column labels are returned with a CSV response; if `false` (the default), they are not. Applies only when the `Accept` header is set to `text/csv`. (optional, default to false)</param>
        /// <param name="consumptionPreferences">If `true`, information about consumption preferences is returned with the results; if `false` (the default), the response does not include the information. (optional, default to false)</param>
        /// <returns><see cref="Profile" />Profile</returns>
        Profile ProfileCsv(Content content, string contentType, string contentLanguage = null, string acceptLanguage = null, bool? rawScores = null, bool? csvHeaders = null, bool? consumptionPreferences = null);
    }
}
