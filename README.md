# DemoP2P.Net

P2P on .Net Framework

## 説明

.Net FrameworkでP2Pをやろうとすると2種類あるのだけど、

1. WCFのNetPeerTcpBinding
2. System.Net.PeerToPeer

1について.Net4.5から非推奨になった事を知らなかったため、取り急ぎ2を調べた。

成果としてサンプルプログラムを公開する。

## 環境

- Visual Studio 2012(for Windows Desktopも可)→Visual Studio 2017でのビルドと動作も確認した。
- .Net Framework 4.5以降
  - APIの提供バージョン
- Unity 2018.1.0b13 (64-bit)
  - beta版を使ったが、途中までは 2017.3.1f1 で作っており、おそらくこれでも問題ない。

## デモアプリ説明

- WindowsDemo 以下は、WinFormで作ったアプリ。
- UnityDemo 以下は、Unityで作ったアプリ。
  - Libのビルドをして作ったEXEファイル2つを、UnityDemo\DemoP2P\Assets\StreamingAssets 以下に置く必要がある。
  - 自分以外のプレイヤー位置に青キューブが表示される。
- 動作確認
  - ローカルネットワーク内のマシン2台でそれぞれ起動はOK。
  - 1マシン内で複数起動はOK。
  - グローバルのテストは行っていない。

## API調査

- 一つのノードが持てるデータは4096バイト+39文字(Unicode)
  - [PeerNameRecord.Data Property](https://docs.microsoft.com/ja-jp/dotnet/api/system.net.peertopeer.peernamerecord.data)
  - [PeerNameRecord.Comment Property](https://docs.microsoft.com/ja-jp/dotnet/api/system.net.peertopeer.peernamerecord.comment)
    - 初期値はnullなのに、nullや空文字列を入れるとエラーになる。
- データを登録せずResolverだけ起動しておいても良いようだ。
- 受信データPeerNameRecordが持つEndPointCollectionプロパティには、データ元のアドレスが設定されている。
  - 自分の環境ではIPv4とIPv6の2項目。
  - このアドレスを使えば直接やり取り出来る。
    - ノードに持たせたいデータが制限を超えてもなんとか出来る。
      - もしくは、初めから制御用のデータのみにした方が良いと考えられる。
  - NAT超えの話があるのでIPv6を使いたいところだが、普及率がまだまだ。
- MonoではSystem.Net.PeerToPeerが未対応。なので中継を行うコンソールアプリを作って実現。そのためWindowsでしか動かない。

## 課題

- System.Net.PeerToPeer.Collaborationを敢えて使わないようにしたが、実際のものを作ろうとすると必要になるかもしれない。
- 他者がデータを追加・更新した事を知る方法。
  - てっきりイベントがあるものと思っていたのだが、見つけられていない。
  - とりあえずタイマーで実装した。
  - 前述のCollaborationにはあるのかも。
- ローカルなら接続相手を勝手に探すようだが、グローバルは初めの一人が必要？
  - 例えば次のような実装ならどうか。
    1. 一台立てたままにしておいて、IPアドレスを公開する。
    1. 自身に接続してきたIPアドレスを記録してリストを作成。接続者に渡す。接続側も持っていたら内容をマージする。
    1. 以降はその一覧を順に試行する。稼働時間や安定性などの情報を含めても良さそう。
    1, ある程度普及したら、立てておいた一台目を止めてもいいかもしれない。

## 連絡先

[RyKishita](https://twitter.com/RyKishita)
