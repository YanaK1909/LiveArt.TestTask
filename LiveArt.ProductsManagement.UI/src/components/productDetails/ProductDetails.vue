<template>
  <div>
    <div class="row back-container">
      <div class="col-md-12"><router-link to="/products" class="btn btn-secondary btn-sm"> back to list</router-link></div>
    </div>
    <ProductInfo :product="product"/>
    <CommentsList :comments="product.comments" :addComment="addComment"/>
  </div>
</template>

<script>
import ProductInfo from './ProductInfo'
import CommentsList from './CommentsList'

export default {
  name: 'ProductDetails',
  props: ['product', 'addComment'],
  components: {
    ProductInfo,
    CommentsList
  }
}
</script>
