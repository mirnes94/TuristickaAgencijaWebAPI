import 'package:turisticka_agencija_mobile_1/models/Gradovi.dart';

import 'base_provider.dart';

class GradoviProvider extends BaseProvider<Gradovi> {
  GradoviProvider() : super("api/Gradovi");

  @override
  Gradovi fromJson(data) {
    return Gradovi.fromJson(data);
  }
}