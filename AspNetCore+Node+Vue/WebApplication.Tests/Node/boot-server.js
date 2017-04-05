var prerendering = require('aspnet-prerendering');

var Vue = require('vue')
Vue.component('my-component', {
  template: '<div>A custom component!</div>'
})
var app = new Vue({
    render: function (h) {
      return h('p', [h('my-component', 'hello world')])
    }
})

var renderer = require('vue-server-renderer').createRenderer()


module.exports = prerendering.createServerRenderer(function(params) {
    return new Promise(function (resolve, reject) {
		
	    renderer.renderToString(app, function (error, result) {
		  if (error) throw error		  
          resolve({
              html: result,              
              globals: {
                  tt: 1
              }
          });
		})
		
    });
});