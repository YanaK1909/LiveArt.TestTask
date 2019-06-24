<template>
<div>
  <ProductsList :productsList="productsList" :deleteProduct="deleteProduct"></ProductsList>
  </div>
</template>

<script>
import ProductsList from './ProductsList'
import webApiService from '../../../services/webApiService'

export default {
  name: 'ProductsManageContainer',
  components: {
    ProductsList
  },
  data () {
    // get data by $route.params.id
    return {
      productsList: {}
    }
  },
  methods: {
    getProductsList: function () {
      let self = this
      webApiService.get(`/product`)
        .then((response) => {
          self.$set(this, 'productsList', response.data)
        })
        .catch((errors) => {
          console.log(errors)
        })
    },
    deleteProduct: function (id) {
      webApiService.delete(`/product/${id}`)
        .then((response) => {
          this.getProductsList()
        })
        .catch((errors) => {
          console.log('Cannot save')
        })
    }
  },
  mounted () {
    this.getProductsList()
  }
}
</script>
