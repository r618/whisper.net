This is a hard fork of [https://github.com/sandrohanea/whisper.net](https://github.com/sandrohanea/whisper.net) with only Unity comaptible/needed parts:

- Unity 2022.2 and up
- sources made compatible with Unity C# version (this might not be needed over time once Unity updates to more recent compiler+CLR)
- IL2CPP compatible - the instance callbacks which IL2CPP doesn't support are static
- Wave audio format support originally included was removed
- GGML downloader removed - models downloads are handled via UnityWebRequest, endpoints [https://github.com/ggerganov/whisper.cpp/blob/master/models/download-ggml-model.sh](https://github.com/ggerganov/whisper.cpp/blob/master/models/download-ggml-model.sh)
- native library loading support was removed - all libraries loading is handled by Unity automatically
- runtime native platforms images are not present in this branch
