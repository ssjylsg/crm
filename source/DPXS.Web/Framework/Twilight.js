/*
 * Author:feitianxinhong
 * CreateDate:2012-10-16
 * CopyRight:Twilight Software Development Studio ©2012
 * Description:Twilight Common JS for JQuery
 */

/**
* @class Twi
* @singleton
*/
(function () {
    var global = this,
        objectPrototype = Object.prototype,
        toString = objectPrototype.toString,
        enumerables = true,
        enumerablesTest = { toString: 1 },
        i;

    if (typeof Twi === 'undefined') {
        global.Twi = {};
    }

    Twi.global = global;

    for (i in enumerablesTest) {
        enumerables = null;
    }

    if (enumerables) {
        enumerables = ['hasOwnProperty', 'valueOf', 'isPrototypeOf', 'propertyIsEnumerable',
                       'toLocaleString', 'toString', 'constructor'];
    }

    /**
    * An array containing extra enumerables for old browsers
    * @property {String[]}
    */
    Twi.enumerables = enumerables;

    /**
    * Copies all the properties of config to the specified object.
    * Note that if recursive merging and cloning without referencing the original objects / arrays is needed, use
    * {@link Twi.Object#merge} instead.
    * @param {Object} object The receiver of the properties
    * @param {Object} config The source of the properties
    * @param {Object} defaults A different object that will also be applied for default values
    * @return {Object} returns obj
    */
    Twi.apply = function (object, config, defaults) {
        if (defaults) {
            Twi.apply(object, defaults);
        }

        if (object && config && typeof config === 'object') {
            var i, j, k;

            for (i in config) {
                object[i] = config[i];
            }

            if (enumerables) {
                for (j = enumerables.length; j--; ) {
                    k = enumerables[j];
                    if (config.hasOwnProperty(k)) {
                        object[k] = config[k];
                    }
                }
            }
        }

        return object;
    };

    Twi.buildSettings = Twi.apply({
        baseCSSPrefix: 'x-',
        scopeResetCSS: false
    }, Twi.buildSettings || {});

    Twi.apply(Twi, {
        /**
        * A reusable empty function
        */
        emptyFn: function () { },

        baseCSSPrefix: Twi.buildSettings.baseCSSPrefix,

        /**
        * Copies all the properties of config to object if they don't already exist.
        * @param {Object} object The receiver of the properties
        * @param {Object} config The source of the properties
        * @return {Object} returns obj
        */
        applyIf: function (object, config) {
            var property;

            if (object) {
                for (property in config) {
                    if (object[property] === undefined) {
                        object[property] = config[property];
                    }
                }
            }

            return object;
        },

        /**
        * Iterates either an array or an object. This method delegates to
        * {@link Twi.Array#each Twi.Array.each} if the given value is iterable, and {@link Twi.Object#each Twi.Object.each} otherwise.
        *
        * @param {Object/Array} object The object or array to be iterated.
        * @param {Function} fn The function to be called for each iteration. See and {@link Twi.Array#each Twi.Array.each} and
        * {@link Twi.Object#each Twi.Object.each} for detailed lists of arguments passed to this function depending on the given object
        * type that is being iterated.
        * @param {Object} scope (Optional) The scope (`this` reference) in which the specified function is executed.
        * Defaults to the object being iterated itself.
        * @markdown
        */
        iterate: function (object, fn, scope) {
            if (Twi.isEmpty(object)) {
                return;
            }

            if (scope === undefined) {
                scope = object;
            }

            if (Twi.isIterable(object)) {
                Twi.Array.each.call(Twi.Array, object, fn, scope);
            }
            else {
                Twi.Object.each.call(Twi.Object, object, fn, scope);
            }
        }
    });

    Twi.apply(Twi, {

        /**
        * This method deprecated. Use {@link Twi#define Twi.define} instead.
        * @method
        * @param {Function} superclass
        * @param {Object} overrides
        * @return {Function} The subclass constructor from the <tt>overrides</tt> parameter, or a generated one if not provided.
        * @deprecated 4.0.0 Use {@link Twi#define Twi.define} instead
        */
        extend: function () {
            // inline overrides
            var objectConstructor = objectPrototype.constructor,
                inlineOverrides = function (o) {
                    for (var m in o) {
                        if (!o.hasOwnProperty(m)) {
                            continue;
                        }
                        this[m] = o[m];
                    }
                };

            return function (subclass, superclass, overrides) {
                // First we check if the user passed in just the superClass with overrides
                if (Twi.isObject(superclass)) {
                    overrides = superclass;
                    superclass = subclass;
                    subclass = overrides.constructor !== objectConstructor ? overrides.constructor : function () {
                        superclass.apply(this, arguments);
                    };
                }

                //<debug>
                if (!superclass) {
                    Twi.Error.raise({
                        sourceClass: 'Twi',
                        sourceMethod: 'extend',
                        msg: 'Attempting to extend from a class which has not been loaded on the page.'
                    });
                }
                //</debug>

                // We create a new temporary class
                var F = function () { },
                    subclassProto, superclassProto = superclass.prototype;

                F.prototype = superclassProto;
                subclassProto = subclass.prototype = new F();
                subclassProto.constructor = subclass;
                subclass.superclass = superclassProto;

                if (superclassProto.constructor === objectConstructor) {
                    superclassProto.constructor = superclass;
                }

                subclass.override = function (overrides) {
                    Twi.override(subclass, overrides);
                };

                subclassProto.override = inlineOverrides;
                subclassProto.proto = subclassProto;

                subclass.override(overrides);
                subclass.extend = function (o) {
                    return Twi.extend(subclass, o);
                };

                return subclass;
            };
        } (),

        /**
        * Proxy to {@link Twi.Base#override}. Please refer {@link Twi.Base#override} for further details.

        Twi.define('My.cool.Class', {
        sayHi: function() {
        alert('Hi!');
        }
        }

        Twi.override(My.cool.Class, {
        sayHi: function() {
        alert('About to say...');

        this.callOverridden();
        }
        });

        var cool = new My.cool.Class();
        cool.sayHi(); // alerts 'About to say...'
        // alerts 'Hi!'

        * Please note that `this.callOverridden()` only works if the class was previously
        * created with {@link Twi#define)
        *
        * @param {Object} cls The class to override
        * @param {Object} overrides The list of functions to add to origClass. This should be specified as an object literal
        * containing one or more methods.
        * @method override
        * @markdown
        */
        override: function (cls, overrides) {
            if (cls.prototype.$className) {
                return cls.override(overrides);
            }
            else {
                Twi.apply(cls.prototype, overrides);
            }
        }
    });

    // A full set of static methods to do type checking
    Twi.apply(Twi, {

        /**
        * Returns the given value itself if it's not empty, as described in {@link Twi#isEmpty}; returns the default
        * value (second argument) otherwise.
        *
        * @param {Object} value The value to test
        * @param {Object} defaultValue The value to return if the original value is empty
        * @param {Boolean} allowBlank (optional) true to allow zero length strings to qualify as non-empty (defaults to false)
        * @return {Object} value, if non-empty, else defaultValue
        */
        valueFrom: function (value, defaultValue, allowBlank) {
            return Twi.isEmpty(value, allowBlank) ? defaultValue : value;
        },

        /**
        * Returns the type of the given variable in string format. List of possible values are:
        *
        * - `undefined`: If the given value is `undefined`
        * - `null`: If the given value is `null`
        * - `string`: If the given value is a string
        * - `number`: If the given value is a number
        * - `boolean`: If the given value is a boolean value
        * - `date`: If the given value is a `Date` object
        * - `function`: If the given value is a function reference
        * - `object`: If the given value is an object
        * - `array`: If the given value is an array
        * - `regexp`: If the given value is a regular expression
        * - `element`: If the given value is a DOM Element
        * - `textnode`: If the given value is a DOM text node and contains something other than whitespace
        * - `whitespace`: If the given value is a DOM text node and contains only whitespace
        *
        * @param {Object} value
        * @return {String}
        * @markdown
        */
        typeOf: function (value) {
            if (value === null) {
                return 'null';
            }

            var type = typeof value;

            if (type === 'undefined' || type === 'string' || type === 'number' || type === 'boolean') {
                return type;
            }

            var typeToString = toString.call(value);

            switch (typeToString) {
                case '[object Array]':
                    return 'array';
                case '[object Date]':
                    return 'date';
                case '[object Boolean]':
                    return 'boolean';
                case '[object Number]':
                    return 'number';
                case '[object RegExp]':
                    return 'regexp';
            }

            if (type === 'function') {
                return 'function';
            }

            if (type === 'object') {
                if (value.nodeType !== undefined) {
                    if (value.nodeType === 3) {
                        return (/\S/).test(value.nodeValue) ? 'textnode' : 'whitespace';
                    }
                    else {
                        return 'element';
                    }
                }

                return 'object';
            }

            //<debug error>
            Twi.Error.raise({
                sourceClass: 'Twi',
                sourceMethod: 'typeOf',
                msg: 'Failed to determine the type of the specified value "' + value + '". This is most likely a bug.'
            });
            //</debug>
        },

        /**
        * Returns true if the passed value is empty, false otherwise. The value is deemed to be empty if it is either:
        *
        * - `null`
        * - `undefined`
        * - a zero-length array
        * - a zero-length string (Unless the `allowEmptyString` parameter is set to `true`)
        *
        * @param {Object} value The value to test
        * @param {Boolean} allowEmptyString (optional) true to allow empty strings (defaults to false)
        * @return {Boolean}
        * @markdown
        */
        isEmpty: function (value, allowEmptyString) {
            return (value === null) || (value === undefined) || (!allowEmptyString ? value === '' : false) || (Twi.isArray(value) && value.length === 0);
        },

        /**
        * Returns true if the passed value is a JavaScript Array, false otherwise.
        *
        * @param {Object} target The target to test
        * @return {Boolean}
        * @method
        */
        isArray: ('isArray' in Array) ? Array.isArray : function (value) {
            return toString.call(value) === '[object Array]';
        },

        /**
        * Returns true if the passed value is a JavaScript Date object, false otherwise.
        * @param {Object} object The object to test
        * @return {Boolean}
        */
        isDate: function (value) {
            return toString.call(value) === '[object Date]';
        },

        /**
        * Returns true if the passed value is a JavaScript Object, false otherwise.
        * @param {Object} value The value to test
        * @return {Boolean}
        * @method
        */
        isObject: (toString.call(null) === '[object Object]') ?
        function (value) {
            // check ownerDocument here as well to exclude DOM nodes
            return value !== null && value !== undefined && toString.call(value) === '[object Object]' && value.ownerDocument === undefined;
        } :
        function (value) {
            return toString.call(value) === '[object Object]';
        },

        /**
        * Returns true if the passed value is a JavaScript 'primitive', a string, number or boolean.
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isPrimitive: function (value) {
            var type = typeof value;

            return type === 'string' || type === 'number' || type === 'boolean';
        },

        /**
        * Returns true if the passed value is a JavaScript Function, false otherwise.
        * @param {Object} value The value to test
        * @return {Boolean}
        * @method
        */
        isFunction:
        // Safari 3.x and 4.x returns 'function' for typeof <NodeList>, hence we need to fall back to using
        // Object.prorotype.toString (slower)
        (typeof document !== 'undefined' && typeof document.getElementsByTagName('body') === 'function') ? function (value) {
            return toString.call(value) === '[object Function]';
        } : function (value) {
            return typeof value === 'function';
        },

        /**
        * Returns true if the passed value is a number. Returns false for non-finite numbers.
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isNumber: function (value) {
            return typeof value === 'number' && isFinite(value);
        },

        /**
        * Validates that a value is numeric.
        * @param {Object} value Examples: 1, '1', '2.34'
        * @return {Boolean} True if numeric, false otherwise
        */
        isNumeric: function (value) {
            return !isNaN(parseFloat(value)) && isFinite(value);
        },

        /**
        * Returns true if the passed value is a string.
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isString: function (value) {
            return typeof value === 'string';
        },

        /**
        * Returns true if the passed value is a boolean.
        *
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isBoolean: function (value) {
            return typeof value === 'boolean';
        },

        /**
        * Returns true if the passed value is an HTMLElement
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isElement: function (value) {
            return value ? value.nodeType === 1 : false;
        },

        /**
        * Returns true if the passed value is a TextNode
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isTextNode: function (value) {
            return value ? value.nodeName === "#text" : false;
        },

        /**
        * Returns true if the passed value is defined.
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isDefined: function (value) {
            return typeof value !== 'undefined';
        },

        /**
        * Returns true if the passed value is iterable, false otherwise
        * @param {Object} value The value to test
        * @return {Boolean}
        */
        isIterable: function (value) {
            return (value && typeof value !== 'string') ? value.length !== undefined : false;
        }
    });

    Twi.apply(Twi, {

        /**
        * Clone almost any type of variable including array, object, DOM nodes and Date without keeping the old reference
        * @param {Object} item The variable to clone
        * @return {Object} clone
        */
        clone: function (item) {
            if (item === null || item === undefined) {
                return item;
            }

            // DOM nodes
            // TODO proxy this to Twi.Element.clone to handle automatic id attribute changing
            // recursively
            if (item.nodeType && item.cloneNode) {
                return item.cloneNode(true);
            }

            var type = toString.call(item);

            // Date
            if (type === '[object Date]') {
                return new Date(item.getTime());
            }

            var i, j, k, clone, key;

            // Array
            if (type === '[object Array]') {
                i = item.length;

                clone = [];

                while (i--) {
                    clone[i] = Twi.clone(item[i]);
                }
            }
            // Object
            else if (type === '[object Object]' && item.constructor === Object) {
                clone = {};

                for (key in item) {
                    clone[key] = Twi.clone(item[key]);
                }

                if (enumerables) {
                    for (j = enumerables.length; j--; ) {
                        k = enumerables[j];
                        clone[k] = item[k];
                    }
                }
            }

            return clone || item;
        },

        /**
        * @private
        * Generate a unique reference of Twi in the global scope, useful for sandboxing
        */
        getUniqueGlobalNamespace: function () {
            var uniqueGlobalNamespace = this.uniqueGlobalNamespace;

            if (uniqueGlobalNamespace === undefined) {
                var i = 0;

                do {
                    uniqueGlobalNamespace = 'ExtBox' + (++i);
                } while (Twi.global[uniqueGlobalNamespace] !== undefined);

                Twi.global[uniqueGlobalNamespace] = Twi;
                this.uniqueGlobalNamespace = uniqueGlobalNamespace;
            }

            return uniqueGlobalNamespace;
        },

        /**
        * @private
        */
        functionFactory: function () {
            var args = Array.prototype.slice.call(arguments);

            if (args.length > 0) {
                args[args.length - 1] = 'var Twi=window.' + this.getUniqueGlobalNamespace() + ';' +
                    args[args.length - 1];
            }

            return Function.prototype.constructor.apply(Function.prototype, args);
        }
    });

    /**
    * Old alias to {@link Twi#typeOf}
    * @deprecated 4.0.0 Use {@link Twi#typeOf} instead
    * @method
    * @alias Twi#typeOf
    */
    Twi.type = Twi.typeOf;

})();

/**
*config:$.ajax(config)的参数
*config.data:参数配置
*config.success:（做了些改进）  twiReturn.success == true时执行的函数
*/
Twi.Ajax = function (config) {
    var ajaxConfig = {};
    Twi.apply(ajaxConfig, config, { 
        url: '/PageHandler.ashx',
        dataType: 'JSON',
        type: 'POST'
    });
    ajaxConfig.success = function (twiReturn, textStatus, jqXHR) {
  
        if (twiReturn.success) {
            if (typeof config.success == "function") config.success(twiReturn);
        }
        else {
            alert(twiReturn.message);
        }
    }
    $.ajax(ajaxConfig);
}


//获取地址栏参数
Twi.GetUrlParam = function (name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    //if (r != null) return decodeURIComponent(r[2]);  
    return null;
} // end GetUrlParam

Twi.GetUrlParam2 = function (name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    //if (r != null) return unescape(r[2]);
    if (r != null) return decodeURIComponent(r[2]);  
    return null;
} // end GetUrlParam

