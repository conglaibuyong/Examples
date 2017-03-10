var prerendering = require('aspnet-prerendering');

var Vue = require('vue')
var app = new Vue({
  render: function (h) {
    return h('p', 'hello world')
  }
})

var renderer = require('vue-server-renderer').createRenderer()


module.exports = prerendering.createServerRenderer(function(params) {
    return new Promise(function (resolve, reject) {
		
	    renderer.renderToString(app, function (error, result) {
		  if (error) throw error		  
			resolve({ html: result });
		})
		
    });
});