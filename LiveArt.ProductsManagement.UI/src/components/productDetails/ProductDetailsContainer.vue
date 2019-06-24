<template>
  <ProductDetails :product="product" :addComment="addComment"></ProductDetails>
</template>

<script>
import ProductDetails from './ProductDetails'
import webApiService from '../../services/webApiService'

export default {
  name: 'ProductDetailsContainer',
  components: {
    ProductDetails
  },
  data () {
    // get data by $route.params.id
    return {
      product: {}
    }
  },
  methods: {
    getProduct: function () {
      let self = this
      let id = this.$route.params.id
      if (id) {
        webApiService.get(`/product/${id}`)
          .then((response) => {
            self.$set(this, 'product', response.data)
          })
          .catch((errors) => {
            console.log(errors)
          })
      }
    },
    addComment: function (e) {
      e.preventDefault()
      let comment = {
        author: e.target.elements.author.value,
        message: e.target.elements.message.value,
        productId: this.product.id
      }
      webApiService.post('/comment', comment)
        .then((response) => {
          this.getProduct()
        })
        .catch((errors) => {
          console.log('Cannot save')
        })
    }
  },
  mounted () {
    this.getProduct()
  }
}
</script>
