リモート環境構築

「git for windows」をインストール
gitが入ったら。任意のフォルダを作り、右クリック、git bashを開く。
git init コマンドでgitのローカルリポジトリを作る。
git remote add origin　<URLプラストークン>　→例 https://<トークン>@github.com/CGengineer/NovelGame.git
git pull origin HEAD   tabでできる
git config --local core.autocrlf false
git config --global core.autocrlf false
git config --global core.safecrlf false

gitattributesない場合は作る
初めて環境構築する場合
.gitattributesを作成

変更する場合
git pull origin master ←確認
git chedckout -b <好きなブランチ名>　＊unityとか
git add .
git commit -m "コメント"
git push origin master （masterは右上のブランチ名）
トークンで入場させられる場合もある。


基本ここまで


何をするか。対策方法
githubのアカウントを作成
gitのメールアドレスとユーザー名の設定をしているかどうか。
gitのコラボレーターの権限をつかしているかどうか。
リポジトリの作成者に、トークンを生成してもらっているかどうか
git remote add origin サーバー名にしているかどうか
コラボレーターに追加した場合、アカウントのメールから認証をしてもらう。

効率化
ブランチをmergeしたら削除できるようにする。
メインブランチをプッシュできないようにする。
ローカルのmasterブランチ以外すべて削除
git checkout master
git branch | xargs git branch -D


変更履歴が違ってプルリクエストが出せない場合
メインブランチに戻って
git pull origin master --allow-unrelated-histories

TK

ghp_1s5u0whMfF0BvlA
HP72ENYNQM7OgOx3pF8cu

画像を圧縮する場合
https://imguma.com/