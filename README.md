# VRMotionRecorder
## これ何？
VRでの動きをCSVデータとして記録するソフトです。
記録するデータは以下の通りです。
- 位置
- 角度
- 加速度
## Unityのバージョン何？
**2020.3.17f1**です。
## 既知の不具合
- Unity Editor上で記録したあとPlay Modeから出るとEditorごとクラッシュする
レポートの回答曰く「Unity 2021以降のバージョンやLTSでやってね！」とのこと。
## めちゃくちゃ参照したサイト
[空間タップできるVRオーバーレイアプリケーションをUnityで作る【コーディングなし】](https://qiita.com/gpsnmeajp/items/3b67223f7f11bb6d93c3)
- いつでもどこでも使えるようにOverlay化する際にここをそのまま使ってます。UIのキャストとかInput Actionとかなにも考えなくても使えるの神。
[UnityでOculusコントローラのセンサーデータを取得する](https://jmpelletier.com/ja/unity%E3%81%A7oculus%E3%82%B3%E3%83%B3%E3%83%88%E3%83%AD%E3%83%BC%E3%83%A9%E3%81%AE%E3%82%BB%E3%83%B3%E3%82%B5%E3%83%BC%E3%83%87%E3%83%BC%E3%82%BF%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B/)
- センサー情報の取り方を参照。実際には加速度とかが取得できないトラップがあったりするけどUnityが悪い。
