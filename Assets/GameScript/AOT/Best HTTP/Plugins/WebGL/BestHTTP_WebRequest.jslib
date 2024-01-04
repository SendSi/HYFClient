var Lib_BEST_HTTP_WebGL_HTTP_Bridge =
{
	/*LogLevels: {
		All: 0,
		Information: 1,
		Warning: 2,
		Error: 3,
		Exception: 4,
		None: 5
	}*/

	$_best_http_request_bridge_global: {
		requestInstances: {},
		nextRequestId: 1,
		loglevel: 2
	},

	XHR_Create: function(method, url, user, passwd, withCredentials)
	{
		var _url = new URL(UTF8ToString(url)); ///*encodeURI*/(UTF8ToString(url)).replace(/\+/g, '%2B').replace(/%252[fF]/ig, '%2F');
		var _method = UTF8ToString(method);

		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(_best_http_request_bridge_global.nextRequestId + ' XHR_Create - withCredentials: ' + withCredentials + ' method: ' + _method + ' url: ' + _url.toString());

		var http = new XMLHttpRequest();

		if (user && passwd)
		{
			var u = UTF8ToString(user);
			var p = UTF8ToString(passwd);

			http.withCredentials = true;
			http.open(_method, _url.toString(), /*async:*/ true , u, p);
		}
		else {
            http.withCredentials = withCredentials;
			http.open(_method, _url.toString(), /*async:*/ true);
        }

		http.responseType = 'arraybuffer';

		_best_http_request_bridge_global.requestInstances[_best_http_request_bridge_global.nextRequestId] = http;
		return _best_http_request_bridge_global.nextRequestId++;
	},

	XHR_SetTimeout: function (request, timeout)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_SetTimeout ' + timeout);

		_best_http_request_bridge_global.requestInstances[request].timeout = timeout;
	},

	XHR_SetRequestHeader: function (request, header, value)
	{
		var _header = UTF8ToString(header);
		var _value = UTF8ToString(value);

		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_SetRequestHeader ' + _header + ' ' + _value);

        if (_header != 'Cookie')
		    _best_http_request_bridge_global.requestInstances[request].setRequestHeader(_header, _value);
        else {
            var cookies = _value.split(';');
            for (var i = 0; i < cookies.length; i++) {
                document.cookie = cookies[i];
            }
        }
	},

    XHR_CopyResponseTo: function (request, array, size) {
        var http = _best_http_request_bridge_global.requestInstances[request];

	    var response = 0;
	    if (!!http.response)
		    response = http.response;

        var responseBytes = new Uint8Array(response);
        var buffer = HEAPU8.subarray(array, array + size);
        buffer.set(responseBytes)
    },

	XHR_SetResponseHandler: function (request, onresponse, onerror, ontimeout, onaborted)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_SetResponseHandler');

		var http = _best_http_request_bridge_global.requestInstances[request];
		// LOAD
		http.onload = function http_onload(e) {
			if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
				console.log(request + '  - onload ' + http.status + ' ' + http.statusText);

			if (onresponse)
			{
				var responseLength = 0;
				if (!!http.response)
					responseLength = http.response.byteLength;

				Module['dynCall_viiiii'](onresponse, request, http.status, 0, responseLength, 0);
			}
		};

		if (onerror)
		{
			http.onerror = function http_onerror(e) {
				function HandleError(err)
				{
					var length = lengthBytesUTF8(err) + 1;
					var buffer = _malloc(length);

					stringToUTF8Array(err, HEAPU8, buffer, length);

					Module['dynCall_vii'](onerror, request, buffer);

					_free(buffer);
				}

				if (e.error)
					HandleError(e.error);
				else
					HandleError("Unknown Error! Maybe a CORS porblem?");
			};
		}

		if (ontimeout)
			http.ontimeout = function http_onerror(e) {
				Module['dynCall_vi'](ontimeout, request);
			};

		if (onaborted)
			http.onabort = function http_onerror(e) {
				Module['dynCall_vi'](onaborted, request);
			};
	},

	XHR_SetProgressHandler: function (request, onprogress, onuploadprogress)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_SetProgressHandler');

		var http = _best_http_request_bridge_global.requestInstances[request];
		if (http)
		{
			if (onprogress)
				http.onprogress = function http_onprogress(e) {
					if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
						console.log(request + ' XHR_SetProgressHandler - onProgress ' + e.loaded + ' ' + e.total);

					if (e.lengthComputable)
						Module['dynCall_viii'](onprogress, request, e.loaded, e.total);
				};

			if (onuploadprogress)
				http.upload.addEventListener("progress", function http_onprogress(e) {
					if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
						console.log(request + ' XHR_SetProgressHandler - onUploadProgress ' + e.loaded + ' ' + e.total);

					if (e.lengthComputable)
						Module['dynCall_viii'](onuploadprogress, request, e.loaded, e.total);
				}, true);
		}
	},

	XHR_Send: function (request, ptr, length)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_Send ' + ptr + ' ' + length);

		var http = _best_http_request_bridge_global.requestInstances[request];

		try {
			if (length > 0)
				http.send(HEAPU8.subarray(ptr, ptr+length));
			else
				http.send();
		}
		catch(e) {
			if (_best_http_request_bridge_global.loglevel <= 4) /*exception*/
				console.error(request + ' ' + e.name + ": " + e.message);
		}
	},

	XHR_GetResponseHeaders: function(request, callback)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_GetResponseHeaders');

        var headers = ''
        var cookies = document.cookie.split(';');
        for(var i = 0; i < cookies.length; ++i) {
            const cookie = cookies[i].trim();

            if (cookie.length > 0)
                headers += "Set-Cookie:" + cookie + "\r\n";
        }

        var additionalHeaders = _best_http_request_bridge_global.requestInstances[request].getAllResponseHeaders().trim();
        if (additionalHeaders.length > 0) {
            headers += additionalHeaders;
            headers += "\r\n";
        }

        headers += "\r\n";

		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log('  "' + headers + '"');

		var byteArray = new Uint8Array(headers.length);
		for(var i=0,j=headers.length;i<j;++i){
			byteArray[i]=headers.charCodeAt(i);
		}

		var buffer = _malloc(byteArray.length);
		HEAPU8.set(byteArray, buffer);

		Module['dynCall_viii'](callback, request, buffer, byteArray.length);

		_free(buffer);
	},

	XHR_GetStatusLine: function(request, callback)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_GetStatusLine');

		var status = "HTTP/1.1 " + _best_http_request_bridge_global.requestInstances[request].status + " " + _best_http_request_bridge_global.requestInstances[request].statusText + "\r\n";

		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(status);

		var byteArray = new Uint8Array(status.length);
		for(var i=0,j=status.length;i<j;++i){
			byteArray[i]=status.charCodeAt(i);
		}
		var buffer = _malloc(byteArray.length);
		HEAPU8.set(byteArray, buffer);

		Module['dynCall_viii'](callback, request, buffer, byteArray.length);

		_free(buffer);
	},

	XHR_Abort: function (request)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_Abort');

		_best_http_request_bridge_global.requestInstances[request].abort();
	},

	XHR_Release: function (request)
	{
		if (_best_http_request_bridge_global.loglevel <= 1) /*information*/
			console.log(request + ' XHR_Release');

		delete _best_http_request_bridge_global.requestInstances[request];
	},

	XHR_SetLoglevel: function (level)
	{
		_best_http_request_bridge_global.loglevel = level;
	}
};

autoAddDeps(Lib_BEST_HTTP_WebGL_HTTP_Bridge, '$_best_http_request_bridge_global');
mergeInto(LibraryManager.library, Lib_BEST_HTTP_WebGL_HTTP_Bridge);
