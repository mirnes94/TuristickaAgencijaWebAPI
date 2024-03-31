import 'package:turisticka_agencija_mobile_1/models/KorisniciUloge.dart';

import 'base_provider.dart';

class KorisniciUlogeProvider extends BaseProvider<KorisniciUloge> {
  KorisniciUlogeProvider() : super("api/KorisniciUloge");

  @override
  KorisniciUloge fromJson(data) {
    return KorisniciUloge.fromJson(data);
  }
}