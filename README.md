# CppProcessCustomTest

MSBuild の機能を使用して、ビルドプロセスに独自の処理を挿入するための
調査のために作成したプロジェクトです。

最終目標はlibclang にソースコードとオプションを渡して含まれる型情報を
解析することです。
これをなるべくハックせず標準的な手法でvcxproj に組み込もうとしています。

必要なものはソースコード、インクルードパス、マクロ定義です。
その他、ソース解析に影響するオプションがあればそれも必要です。
（例えば、プラットフォームによって自動的に定義されるマクロがある、など）

## プロパティの確認

ターミナルでCppProcessCustomTest.vcxproj のディレクトリに移動し、
msbuild コマンドを実行するとMyPreCompile ターゲットでいくつかの
プロパティやメタデータを標準出力に書き出します。
この内容はDirectory.Build.targets で定義しています。

## 自作のカスタムタスクを適用する

コマンドラインで以下を実行します。

```
> msbuild .\CppCustomTask\CppCustomTask.csproj /t:pack
> nuget install CppCustomTask -Source (CppCustomTask\bin\Debug へのフルパス) -OutputDirectory .\CppProcessCustomTest\packages
> msbuild .\CppProcessCustomTest\CppProcessCustomTest.vcxproj /p:Platform=x64 /p:Configuration=Debug
```

CppProcessCustomTask からCppCustomTask を利用する設定はDirectory.Build.props, Directory.Build.targets に記述しています。
