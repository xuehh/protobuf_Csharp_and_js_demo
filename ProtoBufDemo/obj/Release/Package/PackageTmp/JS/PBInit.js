/// <reference path="Long.min.js" />
/// <reference path="ByteBufferAB.min.js" />
/// <reference path="ProtoBuf.min.js" />
function PBFactoryClass(pbfilepath, pbclassname) {
    this.filepath = pbfilepath;
    this.classname = pbclassname;

    this.protobuf = null;
    this.builder = null;
    this.pbclass = null;

    this.init = function () {
        if (!(this.filepath && this.classname)) {
            throw (new Error(".proto file is null or protobuf message name is null. Please check your input para"));
        }

        if (typeof dcodeIO === 'undefined' || !dcodeIO.ProtoBuf) {
            throw (new Error("ProtoBuf.js is not present. Please see www/index.html for manual setup instructions."));
        }
        // 创建ProtoBuf
        if (this.protobuf == null) {
            this.protobuf = dcodeIO.ProtoBuf;
        }
        if (this.builder == null) {
            this.builder = this.protobuf.loadProtoFile(this.filepath);
        }

        if (this.pbclass == null) {
            this.pbclass = this.builder.build(this.classname);

        }
    };
    this.init();
}
//创建新对象
PBFactoryClass.prototype.createModel = function () {
    return new this.pbclass();
}
//json转proto对象
PBFactoryClass.prototype.parseFromJson = function (jsonData) {
    return new this.pbclass(jsonData);
}
//json转buffer
PBFactoryClass.prototype.encodeFromJson = function (jsonData) {
    return this.parseFromJson(jsonData).toArrayBuffer();
}
//编码
PBFactoryClass.prototype.encodeToBuffer = function (proto) {
    return proto.toArrayBuffer();
}
//解码
PBFactoryClass.prototype.decodeFromBuffer = function (bufferData) {
    return this.pbclass.decode(bufferData);
}
//post
PBFactoryClass.prototype.post = function (url, model) {

    console.log(model);
    var buff = this.encodeToBuffer(model);
    console.log(buff);

    var xhr = new XMLHttpRequest();
    xhr.open('post', url, true);
    xhr.responseType = 'arraybuffer';
    xhr.setRequestHeader('Content-Type', 'application/protobuf');
    var pbclass = this.pbclass;
    xhr.onload = function (response) {
        //console.log('response', response)
        //var msg = resMessage.decode(new Uint8Array(xhr.response)) // new Uint8Array() 坑点！
        //console.log('msg', msg)
        //var resObj = resMessage.toObject(msg)
        //console.log('resObj', resObj)

        var by = new Uint8Array(xhr.response);
        var msg = pbclass.decode(by) // new Uint8Array() 坑点！
        console.log('msg', msg)
        return msg;
    }
    
    xhr.send(buff)
}
PBFactoryClass.prototype.postAndCallback = function (url, model, callback) {
    console.log(model);
    var buff = this.encodeToBuffer(model);
    console.log(buff);

    var xhr = new XMLHttpRequest();
    xhr.open('post', url, true);
    xhr.responseType = 'arraybuffer';
    xhr.setRequestHeader('Content-Type', 'application/protobuf');
    var pbclass = this.pbclass;
    xhr.onload = function (response) {
        //console.log('response', response)
        //var msg = resMessage.decode(new Uint8Array(xhr.response)) // new Uint8Array() 坑点！
        //console.log('msg', msg)
        //var resObj = resMessage.toObject(msg)
        //console.log('resObj', resObj)

        var by = new Uint8Array(xhr.response);
        var msg = pbclass.decode(by) // new Uint8Array() 坑点！
        callback(msg);
    }

    xhr.send(buff)
}