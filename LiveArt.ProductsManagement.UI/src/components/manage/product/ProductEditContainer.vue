<template>
  <ProductEdit :product="product" :saveProduct="saveProduct" :onThumbnailImageChanged="onThumbnailImageChanged" :onValueChanged="onValueChanged">
  </ProductEdit>
</template>

<script>
import ProductEdit from './ProductEdit'
import router from '../../../router'
import webApiService from '../../../services/webApiService'

export default {
  name: 'ProductEditContainer',
  components: {
    ProductEdit
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
    onValueChanged: function (e) {
      const field = e.target.name
      this.$set(this.product, field, e.target.value)
    },
    saveProduct: function (e) {
      e.preventDefault()
      let product = {
        name: e.target.elements.name.value,
        description: e.target.elements.description.value,
        thumbnailImage: this.product.thumbnailImage,
        id: this.$route.params.id
      }
      webApiService.post('/product', product)
        .then((response) => {
          router.push('/manage/products')
        })
        .catch((errors) => {
          console.log('Cannot save')
        })
    },
    onThumbnailImageChanged (e) {
      var files = e.target.files || e.dataTransfer.files
      if (!files.length) {
        return
      }

      this.convertImage(files[0])
    },
    convertImage (file) {
      var reader = new FileReader()
      let self = this
      reader.onload = (e) => {
        self.$set(self.product, 'thumbnailImage', e.target.result)
      }

      if (file) {
        reader.readAsDataURL(file)
      }
    }
  },
  mounted () {
    this.getProduct()
  }
}
</script>
