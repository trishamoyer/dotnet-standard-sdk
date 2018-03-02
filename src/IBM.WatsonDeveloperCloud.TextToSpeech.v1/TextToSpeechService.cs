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

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using IBM.WatsonDeveloperCloud.Http;
using IBM.WatsonDeveloperCloud.Service;
using IBM.WatsonDeveloperCloud.TextToSpeech.v1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace IBM.WatsonDeveloperCloud.TextToSpeech.v1
{
    public class TextToSpeechService : WatsonService, ITextToSpeechService
    {
        const string SERVICE_NAME = "text_to_speech";
        const string URL = "https://stream.watsonplatform.net/text-to-speech/api";
        public TextToSpeechService() : base(SERVICE_NAME, URL)
        {
            if(!string.IsNullOrEmpty(this.Endpoint))
                this.Endpoint = URL;
        }

        public TextToSpeechService(string userName, string password) : this()
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            this.SetCredential(userName, password);
        }

        public TextToSpeechService(IClient httpClient) : this()
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            this.Client = httpClient;
        }

        public Voice GetVoice(string voice, string customizationId = null)
        {
            if (string.IsNullOrEmpty(voice))
                throw new ArgumentNullException(nameof(voice));
            Voice result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/voices/{voice}")
                                .WithArgument("customization_id", customizationId)
                                .As<Voice>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public Voices ListVoices()
        {
            Voices result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/voices")
                                .As<Voices>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
        public System.IO.Stream Synthesize(string voice = null, string customizationId = null, Text text, string accept)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (string.IsNullOrEmpty(accept))
                throw new ArgumentNullException(nameof(accept));
            System.IO.Stream result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .PostAsync($"{this.Endpoint}/v1/synthesize")
                                .WithHeader("Accept", accept)
                                .WithArgument("voice", voice)
                                .WithArgument("customization_id", customizationId)
                                .WithBody<Text>(text)
                                .As<System.IO.Stream>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
        public Pronunciation GetPronunciation(string text, string voice = null, string format = null, string customizationId = null)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            Pronunciation result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/pronunciation")
                                .WithArgument("text", text)
                                .WithArgument("voice", voice)
                                .WithArgument("format", format)
                                .WithArgument("customization_id", customizationId)
                                .As<Pronunciation>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
        public VoiceModel CreateVoiceModel(CreateVoiceModel createVoiceModel)
        {
            if (createVoiceModel == null)
                throw new ArgumentNullException(nameof(createVoiceModel));
            VoiceModel result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .PostAsync($"{this.Endpoint}/v1/customizations")
                                .WithBody<CreateVoiceModel>(createVoiceModel)
                                .As<VoiceModel>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public object DeleteVoiceModel(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            object result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .DeleteAsync($"{this.Endpoint}/v1/customizations/{customizationId}")
                                .As<object>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public VoiceModel GetVoiceModel(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            VoiceModel result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/customizations/{customizationId}")
                                .As<VoiceModel>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public VoiceModels ListVoiceModels(string language = null)
        {
            VoiceModels result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/customizations")
                                .WithArgument("language", language)
                                .As<VoiceModels>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public object UpdateVoiceModel(string customizationId, UpdateVoiceModel updateVoiceModel)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            if (updateVoiceModel == null)
                throw new ArgumentNullException(nameof(updateVoiceModel));
            object result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .PostAsync($"{this.Endpoint}/v1/customizations/{customizationId}")
                                .WithBody<UpdateVoiceModel>(updateVoiceModel)
                                .As<object>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
        public object AddWord(string customizationId, string word, Translation translation)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException(nameof(word));
            if (translation == null)
                throw new ArgumentNullException(nameof(translation));
            object result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .PutAsync($"{this.Endpoint}/v1/customizations/{customizationId}/words/{word}")
                                .WithBody<Translation>(translation)
                                .As<object>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public object AddWords(string customizationId, Words customWords)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            if (customWords == null)
                throw new ArgumentNullException(nameof(customWords));
            object result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .PostAsync($"{this.Endpoint}/v1/customizations/{customizationId}/words")
                                .WithBody<Words>(customWords)
                                .As<object>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public object DeleteWord(string customizationId, string word)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException(nameof(word));
            object result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .DeleteAsync($"{this.Endpoint}/v1/customizations/{customizationId}/words/{word}")
                                .As<object>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public Translation GetWord(string customizationId, string word)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException(nameof(word));
            Translation result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/customizations/{customizationId}/words/{word}")
                                .As<Translation>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }

        public Words ListWords(string customizationId)
        {
            if (string.IsNullOrEmpty(customizationId))
                throw new ArgumentNullException(nameof(customizationId));
            Words result = null;

            try
            {
                result = this.Client.WithAuthentication(this.UserName, this.Password)
                                .GetAsync($"{this.Endpoint}/v1/customizations/{customizationId}/words")
                                .As<Words>()
                                .Result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
    }
}
