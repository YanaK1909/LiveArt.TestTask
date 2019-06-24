<template>
<div>
  <ProductsList :productsList="productsList"></ProductsList>
  </div>
</template>

<script>
import ProductsList from './ProductsList'
import webApiService from '../../services/webApiService'

export default {
  name: 'ProductsListContainer',
  components: {
    ProductsList
  },
  data () {
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
    }
  },
  mounted () {
    this.getProductsList()
  }
}
</script>
