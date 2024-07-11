# チートシート

## dotnetで作成可能なテンプレートを確認

```powershell
dotnet new list
```

## ビルド

slnファイルが存在するディレクトリに移動して、ビルドコマンドを実行する。  

```powershell
dotnet build
```

## 実行

```powershell
dotnet run
```

## エンティティフレームワーク

### マイグレーションファイルを作成

```powershell
cd Backend.Api
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```

> InitialCreateは、マイグレーション内容などのコメント。内容に応じて変更する。

### マイグレーション実行

```powershell
dotnet ef database update
```
