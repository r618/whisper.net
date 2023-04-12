This is a hard fork of [https://github.com/sandrohanea/whisper.net](https://github.com/sandrohanea/whisper.net) with only Unity comaptible/needed parts:

- Unity 2022.02 and up
- sources made compatible with Unity C# version (this might not be needed over time once Unity updates to more recent compiler+CLR)
- IL2CPP compatible - the instance callbacks which IL2CPP doesn't support are static
- Wave audio format support originally included was removed
- GGML downloader removed
- native library loading support was removed - all library loading is handled automatically by Unity
- runtime native platforms images are not present either

For original, README, licensing,.. please see [https://github.com/sandrohanea/whisper.net](https://github.com/sandrohanea/whisper.net)
