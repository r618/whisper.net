// Licensed under the MIT license: https://opensource.org/licenses/MIT

using System;
using System.Runtime.InteropServices;
using Whisper.net.Native;

namespace Whisper.net.Internals.ModelLoader
{
    internal class WhisperProcessorModelBufferLoader : IWhisperProcessorModelLoader
    {
        readonly byte[] buffer;
        readonly GCHandle pinnedBuffer;
        readonly bool useGpu;
        public WhisperProcessorModelBufferLoader(byte[] _buffer, bool _useGpu)
        {
            this.buffer = _buffer;
            this.pinnedBuffer = GCHandle.Alloc(this.buffer, GCHandleType.Pinned);
            this.useGpu = _useGpu;
        }

        public void Dispose()
        {
            pinnedBuffer.Free();
        }

        public IntPtr LoadNativeContext()
        {
            var bufferLength = new UIntPtr((uint)buffer.Length);
            return NativeMethods.whisper_init_from_buffer_with_params_no_state(pinnedBuffer.AddrOfPinnedObject(), bufferLength, new WhisperContextParams() { UseGpu = useGpu ? (byte)1 : (byte)0 });
        }
    }
}