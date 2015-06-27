﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace FirebaseSharp.Portable
{
    public sealed class Firebase : IDisposable
    {
        private readonly Request _request;

        public Firebase(string rootUri, string authToken = null)
            : this(new Uri(rootUri), authToken)
        {            
        }

        public Firebase(Uri rootUri, string authToken = null)
        {
            if (rootUri == null)
            {
                throw new ArgumentNullException("rootUri");
            }

            _request = new Request(rootUri, authToken);
        }

        public Uri RootUri
        {
            get { return _request.RootUri; }
        }

        public async Task<string> PostAsync(string path, string payload)
        {
            return await PostAsync(path, payload, CancellationToken.None).ConfigureAwait(false);
        }

        public async Task<string> PostAsync(string path, string payload, CancellationToken cancellationToken)
        {
            return await _request.Post(path, payload, cancellationToken).ConfigureAwait(false);
        }

        public async Task<string> PutAsync(string path, string payload)
        {
            return await PutAsync(path, payload, CancellationToken.None).ConfigureAwait(false);
        }

        public async Task<string> PutAsync(string path, string payload, CancellationToken cancellationToken)
        {
            return await _request.Put(path, payload, cancellationToken).ConfigureAwait(false);
        }


        public async Task<string> PatchAsync(string path, string payload)
        {
            return await PatchAsync(path, payload, CancellationToken.None).ConfigureAwait(false);
        }

        public async Task<string> PatchAsync(string path, string payload, CancellationToken cancellationToken)
        {
            return await _request.Patch(path, payload, cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(string path)
        {
            await DeleteAsync(path, CancellationToken.None).ConfigureAwait(false);
        }

        public async Task DeleteAsync(string path, CancellationToken cancellationToken)
        {
            await _request.Delete(path, cancellationToken).ConfigureAwait(false);
        }

        public async Task<string> GetAsync(string path)
        {
            return await GetAsync(path, CancellationToken.None).ConfigureAwait(false);
        }
        public async Task<string> GetAsync(string path, CancellationToken cancellationToken)
        {
            return await _request.GetSingle(path, cancellationToken).ConfigureAwait(false);
        }

        public async Task<StreamingResponse> GetStreamingAsync(string path,
            ValueAddedEventHandler added,
            ValueChangedEventHandler changed,
            ValueRemovedEventHandler removed)
        {
            return await GetStreamingAsync(path, added, changed, removed, CancellationToken.None).ConfigureAwait(false);
        }

        public async Task<StreamingResponse> GetStreamingAsync(string path,
            ValueAddedEventHandler added,
            ValueChangedEventHandler changed,
            ValueRemovedEventHandler removed,
            CancellationToken cancellationToken)
        {
            return await _request.GetStreaming(path, added, changed, removed, cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            using (_request) { }
        }
    }
}
