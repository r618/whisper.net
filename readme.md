This is a hard fork of [https://github.com/sandrohanea/whisper.net](https://github.com/sandrohanea/whisper.net) with only Unity compatible/needed parts:

- Unity 2022.2 and up
- sources made compatible with Unity C# version (this might not be needed over time once Unity updates to more recent compiler+CLR)
- IL2CPP compatible AOT static callbacks
- Wave audio format support originally included was removed
- original huggingface GGML models endpoints used
- native library loading support was removed - all libraries loading is handled by Unity automatically
- runtime native platforms images are not present in this branch
