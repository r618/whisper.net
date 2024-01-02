// Licensed under the MIT license: https://opensource.org/licenses/MIT

using System;
using System.Runtime.InteropServices;
using Whisper.net.Native;

namespace Whisper.net.Logger
{
    public class LogProvider
    {

        private LogProvider()
        {

        }

        /// <summary>
        /// Returns the singleton instance of the <see cref="LogProvider"/> class used to log messages from the Whisper library.
        /// </summary>
        public static LogProvider Instance { get; } = new();
#nullable enable
        public event Action<WhisperLogLevel, string?>? OnLog;
#nullable restore

        public static void InitializeLogging()
        {
            IntPtr funcPointer;
#if NET6_0_OR_GREATER
        unsafe
        {
            delegate* unmanaged[Cdecl]<GgmlLogLevel, IntPtr, IntPtr, void> onLogging = &LogUnmanaged;
            funcPointer = (IntPtr)onLogging;
        }
#else
            funcPointer = Marshal.GetFunctionPointerForDelegate(logCallback);
#endif
            NativeMethods.whisper_log_set(funcPointer, IntPtr.Zero);
        }
        public static void DeInitializeLogging()
        {
            NativeMethods.whisper_log_set(IntPtr.Zero, IntPtr.Zero);
        }

#if NET6_0_OR_GREATER
        [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
#else

        private static readonly WhisperGgmlLogCallback logCallback = LogUnmanaged;
#endif
        [AOT.MonoPInvokeCallback(typeof(WhisperGgmlLogCallback))]
        internal static void LogUnmanaged(GgmlLogLevel level, IntPtr message, IntPtr user_data)
        {
            var messageString = Marshal.PtrToStringAnsi(message);
            var managedLevel = level switch
            {
                GgmlLogLevel.Error => WhisperLogLevel.Error,
                GgmlLogLevel.Warning => WhisperLogLevel.Warning,
                _ => WhisperLogLevel.Info
            };
            Log(managedLevel, messageString);
        }
#nullable enable
        internal static void Log(WhisperLogLevel level, string? message)
#nullable restore
        {
            Instance.OnLog?.Invoke(level, message);
        }
    }
}