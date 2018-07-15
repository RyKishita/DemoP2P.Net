# DemoP2P.Net

P2P on .Net Framework

## 説明

.Net FrameworkでP2Pをやろうとすると2種類あるのだけど、

1. WCFのNetPeerTcpBinding
2. System.Net.PeerToPeer

1について.Net4.5から非推奨になった事を知らなかったため、取り急ぎ2を調べた。

成果としてサンプルプログラムを公開する。

## 環境

- Visual Studio Community 2017 Version 15.6.7
- .Net Framework 4.5以降
  - APIの提供バージョン
- Unity 2018.1.0f2 (64-bit)

## デモアプリ説明

- WindowsDemo 以下は、WinFormで作ったアプリ。
- UnityDemo 以下は、Unityで作ったアプリ。
  - Libのビルドをして作ったEXEファイル2つを、UnityDemo\DemoP2P\Assets\StreamingAssets 以下に置く必要がある。
  - 自分以外のプレイヤー位置に青キューブが表示される。
- 動作確認
  - ローカルネットワーク内のマシン2台でそれぞれ起動はOK。
  - 1マシン内で複数起動はOK。
  - グローバルのテストは行っていない。

## 調査

- 一つのノードが持てるデータは4096バイト+39文字(Unicode)
  - [PeerNameRecord.Data Property](https://docs.microsoft.com/ja-jp/dotnet/api/system.net.peertopeer.peernamerecord.data)
  - [PeerNameRecord.Comment Property](https://docs.microsoft.com/ja-jp/dotnet/api/system.net.peertopeer.peernamerecord.comment)
    - 初期値はnullなのに、nullや空文字列を入れるとエラーになる。
- データを登録せずResolverだけ起動しておいても良いようだ。
- 受信データPeerNameRecordが持つEndPointCollectionプロパティには、データ元のアドレスが設定されている。
  - このアドレスを使えば直接やり取り出来る。
    - ノードに持たせたいデータが制限を超えても、これを使ってなんとか出来そう。
      - もしくは、初めから制御用のデータのみ置くと考えたほうが良さそう。
- Unityで選択できるのは「.NET 4.x」「.NET Standard 2.0」となっている(Unity 2018.1 時点)。いずれもSystem.Net.PeerToPeerが未対応。
  - 中継を行うコンソールアプリを作って実現。そのためWindowsでしか動かない。

## 課題

- System.Net.PeerToPeer.Collaborationを敢えて使わないようにしたが、実際のものを作ろうとすると必要になるかもしれない。
- 他者がデータを追加・更新した事を知る方法。
  - てっきりイベントがあるものと思っていたのだが、見つけられていない。
  - とりあえずタイマーで実装した。
  - 前述のCollaborationにはあるのかも。
- ローカルなら接続相手を勝手に探すようだが、グローバルは初めの一人が必要？
  - Seed Serverというものがある。[https://msdn.microsoft.com/en-us/library/cc239112.aspx](https://msdn.microsoft.com/en-us/library/cc239112.aspx)
    - 使えるのかどうか未検証。
  - 例えば次のような実装ならどうか。
    1. 一台立てたままにしておいて、IPアドレスを公開する。
    1. 自身に接続してきたIPアドレスを記録してリストを作成。接続者に渡す。接続側も持っていたら内容をマージする。
    1. 以降はその一覧を順に試行する。稼働時間や安定性などの情報を含めても良さそう。
    1. ある程度普及したら、立てておいた一台目を止めてもいいかもしれない。
- PNRPというのが使われており、これはIPv6をベースにしている。
  - IPv4のみ環境でも使えるような記述もあるが、NAT越えを考えると初めから除外したい。
    - だが、IPv6の普及率を考えるとそうも言ってられない。

## 連絡先

[RyKishita](https://twitter.com/RyKishita)
