<template>
  <form v-on:submit="saveProduct">
    <div>
      <div class="row back-container">
        <div class="col-md-12">
          <input type="submit" class="btn btn-primary" value="Save" />
          <router-link to="/manage/products" class="btn btn-secondary">Cancel</router-link>
        </div>
      </div>
      <div class="row product-details">
        <div class="col-md-5">
          <input type="file" class="form-control-file" @change="onThumbnailImageChanged">
          <img :src="product.thumbnailImage" :alt="product.name"/>
        </div>
        <div class="col-md-7">
          <label for="name">Name</label>
          <input type="text" name="name" :value="product.name" id="name" class="form-control" @change="onValueChanged"/>
          <label for="description">Description</label>
          <textarea name="description" :value="product.description" id="description" class="form-control"  @change="onValueChanged" rows="3"/>
        </div>
      </div>
    </div>
  </form>
</template>

<script>

export default {
  name: 'ProductEdit',
  props: ['product', 'saveProduct', 'onValueChanged', 'onThumbnailImageChanged']
}</script>
