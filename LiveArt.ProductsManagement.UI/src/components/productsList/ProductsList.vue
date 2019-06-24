<template>
  <div>
    <section class="jumbotron text-center">
      <h1 class="jumbotron-heading">Products</h1>
    </section>
    <div class="row">
      <div class="col-md-4" v-for="product in productsList"
        :key="product.id">
        <ProductItem :product="product"/>
      </div>
    </div>
  </div>
</template>

<script>
import ProductItem from './ProductItem'

export default {
  name: 'ProductsList',
  props: ['productsList'],
  components: {
    ProductItem
  }
}
</script>
