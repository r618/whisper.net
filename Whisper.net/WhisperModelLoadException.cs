// Licensed under the MIT license: https://opensource.org/licenses/MIT

using System;

namespace Whisper.net
{
    public class WhisperModelLoadException : Exception
    {
        public WhisperModelLoadException(string message) : base(message)
        {
        }
    }
}