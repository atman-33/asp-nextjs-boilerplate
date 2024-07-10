# Git ルール

## コミットメッセージ

- commit message

```txt
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]
```

e.g.  

- commit type： fix
- scope： api
- description： prevent racing of requests
- optional body： Introduce a request id, and add request id to any log message.
- footer(s)：
  - BREAKING CHANGE: drop support for Node 6
  - Refs: #123

```txt
fix(api)!: prevent racing of requests

Introduce a request id, and add request id to any log message.

BREAKING CHANGE: drop support for Node 6
Refs: #123
```

- commit type

```txt
feat: A new feature
fix: A bug fix
docs: Documentation only changes 
style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
refactor: A code change that neither fixes a bug nor adds a feature
perf: A code change that improves performance
test: Adding missing or correcting existing tests
chore: Changes to the build process or auxiliary tools and libraries such as documentation generation
```

- feat: 新しい機能
- fix: バグの修正
- docs: ドキュメントのみの変更
- style: 空白、フォーマット、セミコロン追加など
- refactor: 仕様に影響がないコード改善(リファクタ)
- perf: パフォーマンス向上関連
- test: テスト関連
- chore: ビルド、補助ツール、ライブラリ関連

## 参考URL

[Developing AngularJS](https://github.com/angular/angular.js/blob/master/DEVELOPERS.md#type)

[Conventional Commits 1.0.0](https://www.conventionalcommits.org/ja/v1.0.0/)  

[Conventional Commits - コミットメッセージ仕様](https://zenn.dev/sumiren/articles/418f593dbbf601)  

[commitlintとCommitizenを使ってチーム開発におけるコミットメッセージを統一する](https://zenn.dev/horitaka/articles/commit-message-rules)
