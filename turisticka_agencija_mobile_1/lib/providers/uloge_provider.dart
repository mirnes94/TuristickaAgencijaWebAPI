import 'package:turisticka_agencija_mobile_1/models/Uloge.dart';

import 'base_provider.dart';

class UlogeProvider extends BaseProvider<Uloge> {
  UlogeProvider() : super("api/Uloge");

  @override
  Uloge fromJson(data) {
    return Uloge.fromJson(data);
  }
}