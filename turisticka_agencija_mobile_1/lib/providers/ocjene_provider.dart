import 'package:turisticka_agencija_mobile_1/models/Ocjene.dart';

import 'base_provider.dart';

class OcjeneProvider extends BaseProvider<Ocjene> {
  OcjeneProvider() : super("api/Ocjene");

  @override
  Ocjene fromJson(data) {
    return Ocjene.fromJson(data);
  }
}