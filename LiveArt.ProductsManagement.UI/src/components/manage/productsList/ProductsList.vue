<template>
  <div>
    <div class="products-manage-toolbar">
      <div class="d-flex justify-content-between align-items-center">
        <div class="btn-group">
          <a href="#/manage/product" class="">
            <button type="button" class="btn btn-lg btn-outline-secondary">Add new</button>
          </a>
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-md-4" v-for="product in productsList"
        :key="product.id">
        <ProductItem :product="product" :deleteProduct="deleteProduct"/>
      </div>
    </div>
  </div>
</template>

<script>
import ProductItem from './ProductItem'

export default {
  name: 'ProductsList',
  props: ['productsList', 'deleteProduct'],
  components: {
    ProductItem
  }
}
</script>
