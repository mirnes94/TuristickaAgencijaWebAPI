import 'package:turisticka_agencija_mobile_1/models/Smjestaj.dart';

import 'base_provider.dart';

class SmjestajProvider extends BaseProvider<Smjestaj> {
  SmjestajProvider() : super("api/Smjestaj");

  @override
  Smjestaj fromJson(data) {
    return Smjestaj.fromJson(data);
  }
}