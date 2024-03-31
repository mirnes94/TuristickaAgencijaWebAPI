import 'package:turisticka_agencija_mobile_1/models/Drzava.dart';

import 'base_provider.dart';

class DrzavaProvider extends BaseProvider<Drzava> {
  DrzavaProvider() : super("api/Drzava");

  @override
  Drzava fromJson(data) {
    return Drzava.fromJson(data);
  }
}