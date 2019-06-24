<template>
  <div class="my-3 p-3 bg-white rounded shadow-sm">
    <h6 class="border-bottom border-gray pb-2 mb-0">Comments</h6>

    <small class="d-block text-right mt-3">
      <form v-on:submit="addComment">
        <div class="form-group">
          <input type="text" name="author" id="author" class="form-control" placeholder="Type your name"/>
        </div>
        <div class="form-group">
          <textarea class="form-control" name="message" id="message"  rows="3" placeholder="Type your comment"></textarea>
        </div>
        <input type="submit" class="btn btn-link btn-sm" value="Add comment" />
      </form>
    </small>
    <div class="media text-muted pt-3" v-for="comment in comments" :key="comment.id">
      <svg class="bd-placeholder-img mr-2 rounded" width="32" height="32" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid slice" focusable="false" role="img" aria-label="Placeholder: 32x32"><title>Placeholder</title><rect width="100%" height="100%" fill="#343a40"></rect></svg>
      <div class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
        <div class="d-flex justify-content-between align-items-center w-100">
          <strong class="text-gray-dark">{{comment.author}}</strong>
        </div>
        <span class="d-block">{{comment.message}}</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CommentsList',
  props: ['comments', 'addComment']
}
</script>
