# 開発手順

## 初期設定

### 前提

下記をインストール

- .NET SDK
- VSCode

### 拡張機能

下記をインストール

- C# Dev Kit
- REST Client
- SQLite

### プロジェクト作成

1. VSCode > Ctrl+Shift+P > .NET 新しいプロジェクトを選択する。
2. ASP.NET Core (空) を選択してプロジェクトを作成する。
3. `launchSettings.json`の http/https の launchBrowser を`false`に変更する。

### NuGetパッケージをインストール

1. Apiを実装するプロジェクトに移動する。
2. 必要なNuGetパッケージをインストールする。
   - MinimalApis.Extensions
   - Microsoft.EntityFrameworkCore.Sqlite（SQLiteを利用する場合）
   - dotnet-ef
   - EntityFrameworkCore.Design

**【注意】.NET のVer. に合ったパッケージをインストールすること。**

e.g.  

```powershell
cd Backend.Api
dotnet add package MinimalApis.Extensions --version 0.11.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.7
dotnet tool install --global dotnet-ef --version 8.0.7
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7
```

### EntityFrameworkCoreセットアップ

1. appssettings.json にDB接続文字列を追加
2. Configから取得したDB接続文字列を利用するように変更
3. EntityFrameworkCoreのinfoレベルのログを表示させないようにする。
4. Contextを作成する。
5. DataExtensionsを作成する（アプリ起動時のマイグレーション実行用）。

## API追加

1. Entityを作成する。
2. Dtoを作成する。
3. Mappingを作成する。
4. ContextにEntityを追加する。
5. エンドポイントを作成する。
6. DBマイグレーションファイルを作成する。
7. DBマイグレーションを実行する。
8. デバッグ用のリクエスト送信用httpファイルを作成する。
