DemoP2P.Net
===========

P2P on .Net Framework

##説明

.Net FrameworkでP2Pをやろうとすると2種類あるのだけど、

1. WCFのNetPeerTcpBinding
2. System.Net.PeerToPeer

1について.Net4.5から非推奨になった事を知らなかったため、取り急ぎ2を調べた。

成果としてサンプルプログラムを公開する。

##課題

- System.Net.PeerToPeer.Collaborationを敢えて使わないようにしたが、実際のものを作ろうとすると必要になるかもしれない。
- 他者が更新したら即座に取得したかったのだが、方法が分からずとりあえずタイマーで実装した。
  - てっきりイベントがあるものと思っていたのだが、見つけられていない。
  - 前述のCollaborationにはあるのかも。
- マシン内複数起動によるテストしかしていない。

##情報

Visual Studio 2012(for Windows Desktopも可)

.Net Framework 4.5 (おそらく4.0でも動く)

[RyKishita](https://twitter.com/RyKishita)