# DemoP2P.Net

P2P on .Net Framework

## 説明

.Net FrameworkでP2Pをやろうとすると2種類あるのだけど、

1. WCFのNetPeerTcpBinding
2. System.Net.PeerToPeer

1について.Net4.5から非推奨になった事を知らなかったため、取り急ぎ2を調べた。

成果としてサンプルプログラムを公開する。

## 情報

- Visual Studio 2012(for Windows Desktopも可)→Visual Studio 2017でのビルドと動作も確認した。
- .Net Framework 4.5以降
  - APIの提供バージョン
- 一つのノードが持つデータは4096バイト
  - [PeerNameRecord.Data Property](https://docs.microsoft.com/ja-jp/dotnet/api/system.net.peertopeer.peernamerecord.data)
  - [PeerNameRecord.Comment Property](https://docs.microsoft.com/ja-jp/dotnet/api/system.net.peertopeer.peernamerecord.comment)も使えそうに見えたが「PeerNameオブジェクトに関する」とあるので、ノード毎では無さそう。
- ノードはデータを持たずにResolverだけ起動しておいても良いようだ。
- 動作確認
  - ローカルネットワーク内のマシン2台でそれぞれ起動してのテストはOK。
  - マシン内複数起動によるテストはOK。
  - グローバルのテストは行っていない。

## 課題

- System.Net.PeerToPeer.Collaborationを敢えて使わないようにしたが、実際のものを作ろうとすると必要になるかもしれない。
- 他者がデータを追加・更新した事を知る方法。
  - てっきりイベントがあるものと思っていたのだが、見つけられていない。
  - とりあえずタイマーで実装した。
  - 前述のCollaborationにはあるのかも。
- ローカルなら接続相手を勝手に探すようだ。グローバルは初めの一人が必要？
  1. 一台立てたままにしておいて、IPアドレスを公開する。
  1. 自身に接続してきたIPアドレスを記録して、接続者と交換する。
  1. 以降はその一覧を順に試行する。
  1, ある程度普及したら、立てておいた一台目を止めてもいいかもしれない。

## 連絡先

[RyKishita](https://twitter.com/RyKishita)
