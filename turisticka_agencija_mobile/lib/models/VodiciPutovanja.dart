import 'Vodic.dart';

class VodiciPutovanja {
    int id;
    String putovanje;
    int putovanjeId;
    Vodic vodic;
    int vodicId;

    VodiciPutovanja({required this.id,required this.putovanje,required this.putovanjeId,
        required this.vodic, required this.vodicId});

    factory VodiciPutovanja.fromJson(Map<String, dynamic> json) {
        return VodiciPutovanja(
            id: json['id'], 
            putovanje: json['putovanje'], 
            putovanjeId: json['putovanjeId'],
            vodic: json['vodic'] =  Vodic.fromJson(json['vodic']),
            //vodic: json['vodic'] != null ? Vodic.fromJson(json['vodic']) : null,
            vodicId: json['vodicId'], 
        );
    }

    Map<String, dynamic> toJson() {
        final Map<String, dynamic> data = new Map<String, dynamic>();
        data['id'] = this.id;
        data['putovanje'] = this.putovanje;
        data['putovanjeId'] = this.putovanjeId;
        data['vodicId'] = this.vodicId;
        if (this.vodic != null) {
            data['vodic'] = this.vodic.toJson();
        }
        return data;
    }
}