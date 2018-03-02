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

using IBM.WatsonDeveloperCloud.LanguageTranslator.v2.Model;

namespace IBM.WatsonDeveloperCloud.LanguageTranslator.v2
{
    public interface ILanguageTranslatorService
    {
        /// <summary>
        /// Translate. Translates the input text from the source language to the target language.
        /// </summary>
        /// <param name="request">The translate request containing the text, and either a model ID or source and target language pair.</param>
        /// <returns><see cref="TranslationResult" />TranslationResult</returns>
        TranslationResult Translate(TranslateRequest request);
        /// <summary>
        /// Identify language. Identifies the language of the input text.
        /// </summary>
        /// <param name="text">Input text in UTF-8 format.</param>
        /// <returns><see cref="IdentifiedLanguages" />IdentifiedLanguages</returns>
        IdentifiedLanguages Identify(string text);

        /// <summary>
        /// Identify language. Identifies the language of the input text.
        /// </summary>
        /// <param name="text">Input text in UTF-8 format.</param>
        /// <returns><see cref="IdentifiedLanguages" />IdentifiedLanguages</returns>
        IdentifiedLanguages IdentifyPlain(string text);

        /// <summary>
        /// List identifiable languages. Lists the languages that the service can identify. Returns the language code (for example, `en` for English or `es` for Spanish) and name of each language.
        /// </summary>
        /// <returns><see cref="IdentifiableLanguages" />IdentifiableLanguages</returns>
        IdentifiableLanguages ListIdentifiableLanguages();
        /// <summary>
        /// Create model. Uploads a TMX glossary file on top of a domain to customize a translation model.  Depending on the size of the file, training can range from minutes for a glossary to several hours for a large parallel corpus. Glossary files must be less than 10 MB. The cumulative file size of all uploaded glossary and corpus files is limited to 250 MB.
        /// </summary>
        /// <param name="baseModelId">The model ID of the model to use as the base for customization. To see available models, use the `List models` method.</param>
        /// <param name="name">An optional model name that you can use to identify the model. Valid characters are letters, numbers, dashes, underscores, spaces and apostrophes. The maximum length is 32 characters. (optional)</param>
        /// <param name="forcedGlossary">A TMX file with your customizations. The customizations in the file completely overwrite the domain translaton data, including high frequency or high confidence phrase translations. You can upload only one glossary with a file size less than 10 MB per call. (optional)</param>
        /// <param name="parallelCorpus">A TMX file that contains entries that are treated as a parallel corpus instead of a glossary. (optional)</param>
        /// <param name="monolingualCorpus">A UTF-8 encoded plain text file that is used to customize the target language model. (optional)</param>
        /// <returns><see cref="TranslationModel" />TranslationModel</returns>
        TranslationModel CreateModel(string baseModelId, string name = null, System.IO.Stream forcedGlossary = null, System.IO.Stream parallelCorpus = null, System.IO.Stream monolingualCorpus = null);

        /// <summary>
        /// Delete model. Deletes a custom translation model.
        /// </summary>
        /// <param name="modelId">Model ID of the model to delete.</param>
        /// <returns><see cref="DeleteModelResult" />DeleteModelResult</returns>
        DeleteModelResult DeleteModel(string modelId);

        /// <summary>
        /// Get model details. Gets information about a translation model, including training status for custom models.
        /// </summary>
        /// <param name="modelId">Model ID of the model to get.</param>
        /// <returns><see cref="TranslationModel" />TranslationModel</returns>
        TranslationModel GetModel(string modelId);

        /// <summary>
        /// List models. Lists available translation models.
        /// </summary>
        /// <param name="source">Specify a language code to filter results by source language. (optional)</param>
        /// <param name="target">Specify a language code to filter results by target language. (optional)</param>
        /// <param name="defaultModels">If the defaultModels parameter isn't specified, the service will return all models (defaultModels and non-defaultModels) for each language pair. To return only defaultModels models, set this to `true`. To return only non-defaultModels models, set this to `false`. (optional)</param>
        /// <returns><see cref="TranslationModels" />TranslationModels</returns>
        TranslationModels ListModels(string source = null, string target = null, bool? defaultModels = null);
    }
}
